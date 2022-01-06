using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Data.Core;
using RestApi.Infrastructure.Data.Repositories.Contracts;
using RestApi.Infrastructure.Data.Service.Paging;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace RestApi.Infrastructure.Data.Repositories.Core
{
    public class SqlRepository<T, Key> : IRepository<T, Key>
        where T : class, IEntity<Key>
    {
        private CatalogContext _context;
        protected DbSet<T> _set;

        public SqlRepository(CatalogContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }
        #region CRUD

        public async virtual Task AddNew(T entity)
        {
             await _set.AddAsync(entity);
             await _context.SaveChangesAsync();
        }

        //public Task<IEnumerable<T>> GetAll() => Task.Run(() => _set.AsEnumerable());


        public async Task<T> GetById(Key id) => await _set.FindAsync(id);


        public Task Remove(T entity)
        {
            _set.Remove(entity);
            return _context.SaveChangesAsync();

        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        #endregion
        #region Filter
        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate) => await _set.Where(predicate).ToListAsync();

        public virtual Task<PagedList<T>> Search(string searchText, PagingParam paging = null, string sorting = "")
        {
            throw new NotImplementedException ();
        }
          

        #endregion
    }
}
