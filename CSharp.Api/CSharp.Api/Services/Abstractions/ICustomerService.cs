using CSharp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Services.Abstractions
{
    public interface ICustomerService : IBaseDomainService<Customer>
    {
        Customer Get(long id);

        IEnumerable<Customer> GetAll();

        Customer Add(Customer entity);
    }
}
