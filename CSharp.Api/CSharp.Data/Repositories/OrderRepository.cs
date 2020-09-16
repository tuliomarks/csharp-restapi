using CSharp.Data.Models;
using CSharp.Data.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        readonly BaseDbContext _dbContext;

        public OrderRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Add(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var ret = _dbContext.Order.Add(entity);
            _dbContext.SaveChanges();

            return ret.Entity;
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(long id)
        {
            return _dbContext.Order
                .SingleOrDefault(b => b.Id == id && !b.Deleted);
        }

        public IEnumerable<Order> GetAll()
        {
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;
            return _dbContext.Order.Where(x=> !x.Deleted).ToList();
        }

        public void Update(Order entityToUpdate, Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
