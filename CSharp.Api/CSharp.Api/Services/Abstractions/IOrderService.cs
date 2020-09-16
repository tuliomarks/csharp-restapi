using CSharp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Services.Abstractions
{
    public interface IOrderService : IBaseDomainService<Order>
    {
        Order Get(long id);

        IEnumerable<Order> GetAll();
    }
}
