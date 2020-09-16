using CSharp.Api.Models;
using CSharp.Data.Models;
using CSharp.Data.Repositories;
using CSharp.Data.Services;
using CSharp.Data.Services.Abstractions;
using CSharp.Data.Tests.FakeContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharp.Data.Tests
{
    public class CustomerServiceTests
    {
        BaseDbContext _context;
        ICustomerService _service;
        ICustomerRepository _repository;

        public CustomerServiceTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new CustomerRepository(_context);
            _service = new CustomerService(_repository);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOnlyNotDeletedCustomers()
        {
            // Act
            var list = _service.GetAll();

            // Assert
            var items = Assert.IsType<Api.Models.Customer[]>(list);
            Assert.Equal(2, items.Length);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsCustomersWithoutOrders()
        {
            // Act
            // For some reason the memory database return always the relations
            // Check how to solve this
            var list = _service.GetAll();

            // Assert
            Assert.False(list.Any(x => x.Orders.Count() > 0));
        }

        [Fact]
        public void Get_UnknownIdPassed_ReturnsNull()
        {
            //Arrange 
            var id = -1;

            // Act
            var obj = _service.Get(id);

            // Assert
            Assert.Null(obj);
        }

        [Fact]
        public void Get_KnownIdAndDeleted_ReturnsNull()
        {
            //Arrange 
            var id = 3;

            // Act
            var obj = _service.Get(id);

            // Assert
            Assert.Null(obj);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObj()
        {
            //Arrange 
            var id = 1;

            // Act
            var obj = _service.Get(id);

            // Assert
            Assert.IsType<Api.Models.Customer>(obj);
            Assert.NotNull(obj);
            Assert.Equal(1, obj.Id);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObjWithOrders()
        {
            // Act
            var obj = _service.Get(1);

            // Assert
            Assert.IsType<Api.Models.Customer>(obj);
            Assert.NotEmpty(obj.Orders);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            // Arrange 
            var customer = new Api.Models.Customer() { Id = 0, Name = "Test", Email = "Test@gmail.com" };

            // Act
            var obj = _service.Add(customer);

            // Assert
            Assert.IsType<Api.Models.Customer>(obj);
            Assert.True(obj.Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsException()
        {
            // Arrange 
            Api.Models.Customer customer = null;

            // Act
            Action act = () => { _service.Add(customer); };

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

    }
}
