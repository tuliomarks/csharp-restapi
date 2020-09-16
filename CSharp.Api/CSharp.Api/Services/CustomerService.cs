using CSharp.Data.Services.Abstractions;
using CSharp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CSharp.Api.Models;
using CSharp.Api.Models.Mappings;
using Microsoft.AspNetCore.Connections.Features;

namespace CSharp.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Get(long id)
        {
            var obj = _repository.Get(id);
            return CustomerMap.Map(obj);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll().Select(x => CustomerMap.Map(x)).ToArray();
        }

        public Customer Add(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var ret = _repository.Add(CustomerMap.MapBack(entity));
            return CustomerMap.Map(ret);
        }
    }
}
