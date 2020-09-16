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
    public class OrderServiceTests
    {
        BaseDbContext _context;
        IOrderService _service;
        IOrderRepository _repository;

        public OrderServiceTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new OrderRepository(_context);
            _service = new OrderService(_repository);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            // Arrange 
            var order = new Api.Models.Order() { Id = 0, Price = 11.11M, CreatedDate = DateTime.Now };

            // Act
            var obj = _service.Add(order);

            // Assert
            Assert.IsType<Api.Models.Order>(obj);
            Assert.True(obj.Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsException()
        {
            // Arrange 
            Api.Models.Order order = null;

            // Act
            Action act = () => { _service.Add(order); };

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

    }
}
