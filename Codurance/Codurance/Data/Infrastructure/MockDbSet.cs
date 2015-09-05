using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Codurance.Data.Infrastructure
{
    public class MockDbSet<TEntity> : IDbSet<TEntity> where TEntity : Entity
    {
        private enum EntityState
        {
            Added,
            Modified,
            Deleted
        }

        private class DataItem
        {
            public EntityState EntityState { get; set; }
            public TEntity Data { get; set; }
        }

        private readonly List<TEntity> _data;
        private readonly Dictionary<Guid, DataItem> _modifyData;
        private readonly IQueryable _query;


        public MockDbSet()
        {
            _data = new List<TEntity>();
            _modifyData = new Dictionary<Guid, DataItem>();
            _query = _data.AsQueryable();
        }

        public TEntity Add(TEntity entity)
        {
            // generate new Id
            entity.GenerateNewIdentity();

            if (_modifyData.ContainsKey(entity.Id))
                throw new Exception("Item already been Inserted");

            if (_data.Any(item => item.Id == entity.Id))
                throw new Exception("Item already been in data list");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Added,
                Data = entity
            });

            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            if (_modifyData.ContainsKey(entity.Id))
                throw new Exception("Item already been deleted");

            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("Delete item not in data list");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Deleted,
                Data = entity
            });

            return entity;
        }

        public void Update(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("Update item not in data list");

            if (_modifyData.ContainsKey(entity.Id))
                throw new Exception("Item already been updated");

            _modifyData.Add(entity.Id, new DataItem()
            {
                EntityState = EntityState.Modified,
                Data = entity
            });
        }

        public void SaveChanges()
        {
            foreach (var item in _modifyData)
            {
                switch (item.Value.EntityState)
                {
                    case EntityState.Added:
                        InsertData(item.Value.Data);
                        break;
                    case EntityState.Modified:
                        UpdateData(item.Value.Data);
                        break;
                    case EntityState.Deleted:
                        DeleteData(item.Value.Data);
                        break;
                }
            }
            _modifyData.Clear();
        }

        private void InsertData(TEntity entity)
        {
            if (_data.Any(item => item.Id == entity.Id))
                throw new Exception("The item already in list.");
            _data.Add(entity);
        }

        private void UpdateData(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("The item want to update is not in list.");
            _data.Remove(entity);
            _data.Add(entity);
        }

        private void DeleteData(TEntity entity)
        {
            if (_data.All(item => item.Id != entity.Id))
                throw new Exception("The item want to delete is not in list.");
            _data.Remove(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public Expression Expression
        {
            get { return _query.Expression; }            
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public IQueryProvider Provider {
            get { return _query.Provider; }
        }

        public void Dispose()
        {
            _data.Clear();
            _modifyData.Clear();
        }
    }
}
