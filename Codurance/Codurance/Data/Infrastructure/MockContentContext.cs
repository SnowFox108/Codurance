using System;
using System.Collections.Generic;
using System.Reflection;

namespace Codurance.Data.Infrastructure
{
    public class MockContentContext : IContentContext
    {
        private bool _disposed;
        private readonly Dictionary<string, object> _dbSets;
        
        public MockContentContext()
        {
            _dbSets = new Dictionary<string, object>(); 
        }

        public void SaveChanges()
        {
            DbSetCallMethod("SaveChanges");
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : Entity
        {
            var type = typeof(TEntity).Name;

            if (_dbSets.ContainsKey(type))
                return (MockDbSet<TEntity>)_dbSets[type];

            var dbSetType = typeof(MockDbSet<>);
            _dbSets.Add(type, Activator.CreateInstance(dbSetType.MakeGenericType(typeof(TEntity))));

            return (MockDbSet<TEntity>)_dbSets[type];
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                DbSetCallMethod("Dispose");
                _dbSets.Clear();
            }
            _disposed = true;
        }

        private void DbSetCallMethod(string methodName)
        {
            foreach (var dbSet in _dbSets)
            {
                var dbSetType = dbSet.Value.GetType();
                MethodInfo methodInfo = dbSetType.GetMethod(methodName);
                methodInfo.Invoke(dbSet.Value, null);
            }            
        }

    }
}
