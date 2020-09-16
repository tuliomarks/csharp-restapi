using CSharp.Data.Models;
using CSharp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharp.Data.Tests.FakeContext
{
    public class DataFixture : IDisposable
    {
        public BaseDbContext DbContext { get; private set; }

        public DataFixture()
        {
            var options = new DbContextOptionsBuilder<BaseDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            DbContext = new BaseDbContext(options);

            DbContext.Customer.Add(new Customer() { Id = 1, Name = "John Bala Jones", Email = "john@gmail.com", Deleted = false });
            DbContext.Customer.Add(new Customer() { Id = 2, Name = "Maria", Email = "maria@gmail.com", Deleted = false });
            DbContext.Customer.Add(new Customer() { Id = 3, Name = "Test Deleted", Email = "test@gmail.com", Deleted = true });

            DbContext.Order.Add(new Order() { Id = 1, CustomerId = 1, Deleted = false, Price = 11.11M, CreatedDate = DateTime.Now });
            DbContext.Order.Add(new Order() { Id = 2, CustomerId = 2, Deleted = true, Price = 1221, CreatedDate = DateTime.Now });

            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
