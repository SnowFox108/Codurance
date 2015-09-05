
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codurance.Data.Infrastructure
{
    public interface IDbSet<TEntity>: IQueryable, IEnumerable<TEntity>, IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity entity);
        TEntity Remove(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
    }
}
