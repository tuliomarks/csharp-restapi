using CSharp.Data.Services.Abstractions;
using CSharp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CSharp.Api.Models;
using CSharp.Api.Models.Mappings;

namespace CSharp.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Get(long id)
        {
            var obj = _repository.Get(id);                
            return OrderMap.Map(obj);
        }

        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll().Select(x => OrderMap.Map(x)).ToArray();
        }

        public Order Add(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var ret = _repository.Add(OrderMap.MapBack(entity));
            return OrderMap.Map(ret);
        }

    }
}
