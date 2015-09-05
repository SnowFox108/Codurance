
using System;

namespace Codurance.Data.Infrastructure
{
    public interface IContentContext : IDisposable
    {
        void SaveChanges();
        IDbSet<TEntity> DbSet<TEntity>() where TEntity : Entity;
    }
}
