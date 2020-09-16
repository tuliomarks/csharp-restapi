using Albelli.Data.Models;
using Albelli.Data.Dependencies;
using System.Collections.Generic;

namespace Albelli.Data.Repositories
{
    public interface ICustomerRepository : IDataRepository<Customer>
    {
        Customer Add(Customer entity);
        void Delete(Customer entity);
        Customer Get(long id);
        IEnumerable<Customer> GetAll();
        void Update(Customer entityToUpdate, Customer entity);
    }
}