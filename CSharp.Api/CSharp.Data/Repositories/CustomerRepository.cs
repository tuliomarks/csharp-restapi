using Albelli.Data.Models;
using Albelli.Data.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Albelli.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        readonly BaseDbContext _dbContext;

        public CustomerRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer Add(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var ret = _dbContext.Customer.Add(entity);
            _dbContext.SaveChanges();

            return ret.Entity;
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(long id)
        {
            return _dbContext.Customer
                .Include(x => x.Orders)
                .SingleOrDefault(b => b.Id == id && !b.Deleted);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customer.Where(x=> !x.Deleted).ToList();
        }

        public void Update(Customer entityToUpdate, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
