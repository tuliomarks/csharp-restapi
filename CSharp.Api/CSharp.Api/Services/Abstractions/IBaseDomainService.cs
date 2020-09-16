using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Services.Abstractions
{
    public interface IBaseDomainService<TEntity>
    {
        TEntity Get(long id);

        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity entity);
    }
}
