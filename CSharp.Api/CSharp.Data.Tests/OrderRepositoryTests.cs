using CSharp.Data.Models;
using CSharp.Data.Repositories;
using CSharp.Data.Tests.FakeContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace CSharp.Data.Tests
{
    public class OrderRepositoryTests
    {
        BaseDbContext _context;
        OrderRepository _repository;

        public OrderRepositoryTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new OrderRepository(_context);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            // Act
            var obj = _repository.Add(new Order() { Id = 0, Price = 1234, CreatedDate = DateTime.Now });

            // Assert
            Assert.IsType<Order>(obj);
            Assert.True(obj.Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsException()
        {
            // Act
            Action act = () => {_repository.Add(null); };

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
