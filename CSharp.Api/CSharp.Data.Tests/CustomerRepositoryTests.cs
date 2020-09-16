using CSharp.Data.Models;
using CSharp.Data.Repositories;
using CSharp.Data.Tests.FakeContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace CSharp.Data.Tests
{
    public class CustomerRepositoryTests
    {
        BaseDbContext _context;
        CustomerRepository _repository;

        public CustomerRepositoryTests()
        {
            _context = new DataFixture().DbContext;
            _repository = new CustomerRepository(_context);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOnlyNotDeletedCustomers()
        {
            // Act
            var list = _repository.GetAll();

            // Assert
            var items = Assert.IsType<List<Customer>>(list);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsCustomersWithoutOrders()
        {
            // Act
            
            // For some reason the memory database return always the relations
            // Check how to solve this
            var list = _repository.GetAll();
            var array = list.ToArray();

            // Assert
            Assert.False(array.Any(x => x.Orders.Count() > 0));
        }

        [Fact]
        public void Get_UnknownIdPassed_ReturnsNull()
        {
            // Act
            var obj = _repository.Get(-1);

            // Assert
            Assert.Null(obj);
        }

        [Fact]
        public void Get_KnownIdAndDeleted_ReturnsNull()
        {
            // Act
            var obj = _repository.Get(3);

            // Assert
            Assert.Null(obj);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObj()
        {
            // Act
            var obj = _repository.Get(1);

            // Assert
            Assert.IsType<Customer>(obj);
            Assert.NotNull(obj);
            Assert.Equal(1, obj.Id);
        }

        [Fact]
        public void Get_KnownIdPassed_ReturnsObjWithOrders()
        {
            // Act
            var obj = _repository.Get(1);

            // Assert
            Assert.IsType<Customer>(obj);
            Assert.NotEmpty(obj.Orders);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsObjWithId()
        {
            // Act
            var obj = _repository.Add(new Customer() { Id = 0, Name = "Test", Email = "Test@gmail.com" });

            // Assert
            Assert.IsType<Customer>(obj);
            Assert.True(obj.Id > 0);
        }

        [Fact]
        public void Add_PassingNullObj_ReturnsException()
        {
            // Act
            Action act = () => { _repository.Add(null); };

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Delete_WhenCalled_ThrowException()
        {
            // Act
            Action act = () => _repository.Delete(new Customer() { Id = 1 });

            //Assert
            var exception = Assert.Throws<NotImplementedException>(act);
        }

        [Fact]
        public void Update_WhenCalled_ThrowException()
        {
            // Act
            Action act = () => _repository.Update(new Customer() { Id = 1 }, new Customer());

            //Assert
            var exception = Assert.Throws<NotImplementedException>(act);
        }
    }
}
