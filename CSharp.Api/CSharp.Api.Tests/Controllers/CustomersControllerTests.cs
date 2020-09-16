using CSharp.Api.Controllers;
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
    public class CustomersControllerTests
    {
        BaseDbContext _context;
        ICustomerService _service;
        ICustomerRepository _repository;
        CustomersController _controller;

        public CustomersControllerTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new CustomerRepository(_context);
            _service = new CustomerService(_repository);
            _controller = new CustomersController(_service);
        }

        [Fact]
        public void List_WhenCalled_ReturnCustomers()
        {
            // Act
            var result = _controller.List();

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            var list = Assert.IsType<Api.Models.Customer[]>(resultOk.Value);
            Assert.NotEmpty(list);
        }

        [Fact]
        public void List_WhenCalled_ReturnsCustomersWithoutOrders()
        {
            // Act
            // For some reason the memory database return always the relations
            // Check how to solve this
            var result = _controller.List();

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            var list = Assert.IsType<Api.Models.Customer[]>(resultOk.Value);
            Assert.NotEmpty(list);
            Assert.False(list.Any(x => x.Orders.Count() > 0));
           
        }

        [Fact]
        public void Get_UnknownIdPassed_ReturnsNull()
        {
            // Assert
            var id = -1;

            // Act
            var result = _controller.Get(id);

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            Assert.Null(resultOk.Value);
        }

        [Fact]
        public void Get_KnownIdAndDeleted_ReturnsNull()
        {
            // Assert
            var id = 3;

            // Act
            var result = _controller.Get(id);

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            Assert.Null(resultOk.Value);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObj()
        {
            // Assert
            var id = 1;
            var expected = new Api.Models.Customer() { Id = 1, Name = "John Bala Jones", Email = "john@gmail.com" };

            // Act
            var result = _controller.Get(id);

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(resultOk.Value);
            var obj = Assert.IsType<Api.Models.Customer>(resultOk.Value);
            Assert.Equal(expected.Id, obj.Id);
            Assert.Equal(expected.Name, obj.Name);
            Assert.Equal(expected.Email, obj.Email);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObjWithOrders()
        {
            // Assert
            var id = 1;

            // Act
            var result = _controller.Get(id);

            // Assert
            var resultOk = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(resultOk.Value);
            var obj = Assert.IsType<Api.Models.Customer>(resultOk.Value);
            Assert.NotEmpty(obj.Orders);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            //Arrange
            var input = new Api.Models.Customer() { Name = "Test", Email = "Test@gmail.com" };

            // Act
            var result = _controller.Add(input);
            var okResult = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Api.Models.Customer>(okResult.Value);
            Assert.True(((Api.Models.Customer)okResult.Value).Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsBadRequestWithException()
        {
            //Arrange
            Api.Models.Customer input = null;

            // Act
            var result = _controller.Add(input);
            var badRequest = result as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ArgumentNullException>(badRequest.Value);
        }

    }
}
