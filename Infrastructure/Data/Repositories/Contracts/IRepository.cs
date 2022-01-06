using RestApi.Domain.Data.Core;
using RestApi.Infrastructure.Data.Service.Paging;
using System.Linq.Expressions;

namespace RestApi.Infrastructure.Data.Repositories.Contracts
{
    public interface IRepository<T, Key>
        where T : IEntity<Key>
    {
        #region CRUD
        Task<T> GetById(Key id);
        Task AddNew(T entity);
        //Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Remove(T entity);
        #endregion
        #region Filter
        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate);
        Task<PagedList<T>> Search(string predicate, PagingParam paging = null, string sorting = "");
        #endregion
    }
}
