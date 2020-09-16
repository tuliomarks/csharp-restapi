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
    public class OrdersControllerTests
    {
        BaseDbContext _context;
        IOrderService _service;
        IOrderRepository _repository;
        OrdersController _controller;

        public OrdersControllerTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new OrderRepository(_context);
            _service = new OrderService(_repository);
            _controller = new OrdersController(_service);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            //Arrange
            var input = new Api.Models.Order() { Price = 11.11M, CreatedDate = DateTime.Now };

            // Act
            var result = _controller.Add(input);
            var okResult = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Api.Models.Order>(okResult.Value);
            Assert.True(((Api.Models.Order)okResult.Value).Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsBadRequestWithException()
        {
            //Arrange
            Api.Models.Order input = null;

            // Act
            var result = _controller.Add(input);
            var badRequest = result as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ArgumentNullException>(badRequest.Value);
        }

    }
}
