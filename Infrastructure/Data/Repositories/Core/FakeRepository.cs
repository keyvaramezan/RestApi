using RestApi.Domain.Data.Core;
using RestApi.Infrastructure.Data.Repositories.Contracts;

namespace RestApi.Infrastructure.Data.Repositories.Core
{
    //public class FakeRepository<T, Key> : IRepository<T, Key>
    //    where T : IEntity<Key>
    //{
    //    private Dictionary<Key, T> _storage;
    //    public FakeRepository()
    //    {
    //        _storage = new Dictionary<Key, T>();
    //    }

    //    public virtual void AddNew(T entity)
    //    {
    //        _storage.Add(entity.Id, entity);
    //    }

    //    public IEnumerable<T> GetAll() => _storage.Values;


    //    public T GetById(Key id)
    //    {
    //        if (_storage.ContainsKey(id))
    //        {
    //            return _storage[id];
    //        }
    //        else
    //        {
    //            return default(T);
    //        }
    //    }

    //    public void Remove(T entity)
    //    {
    //        _storage.Remove(entity.Id);
    //    }

    //    public void Update(T entity)
    //    {
    //        _storage[entity.Id] = entity;
    //    }
    //}
}
