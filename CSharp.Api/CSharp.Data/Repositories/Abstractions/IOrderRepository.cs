using Albelli.Data.Models;
using Albelli.Data.Dependencies;
using System.Collections.Generic;

namespace Albelli.Data.Repositories
{
    public interface IOrderRepository : IDataRepository<Order>
    {
        Order Add(Order entity);
        void Delete(Order entity);
        Order Get(long id);
        IEnumerable<Order> GetAll();
        void Update(Order entityToUpdate, Order entity);
    }
}