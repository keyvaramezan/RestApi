using Microsoft.EntityFrameworkCore;
using RestApi.Domain;
using RestApi.Infrastructure.Data.Repositories.Contracts;
using RestApi.Infrastructure.Data.Repositories.Core;
using RestApi.Infrastructure.Data.Service.Paging;
using System.Linq.Dynamic.Core;

namespace RestApi.Infrastructure.Data.Repositories
{
    public class SqlProductRepository : SqlRepository<Product, int>, IProductRepository
    {
        public SqlProductRepository(CatalogContext context) : base(context)
        {
        }
        //public Task<IEnumerable<Product>> GetByMinPrice(int minPrice) => Filter(p => p.Price >= minPrice);
        //public Task<IEnumerable<Product>> GetByMaxPrice(int maxPrice) => Filter(p => p.Price <= maxPrice);

        //public Task<IEnumerable<Product>> GetByRangePrice(int minPrice, int maxPrice) =>
        //    Filter(p => p.Price >= minPrice && p.Price <= maxPrice);

        //public Task<IEnumerable<Product>> GetByQuery(int minPrice, int maxPrice) => 
        //    Filter($"p => p.Price >= {minPrice} && p.Price <= {maxPrice}");
        public override async Task<PagedList<Product>> Search(string searchText, PagingParam paging = null, string sorting = "")
        {
            return await _set
                             .Where(product =>
                                               EF.Functions.Like(product.Id.ToString(), $"%{searchText}%") ||
                                               EF.Functions.Like(product.Name, $"%{searchText}%") ||
                                               EF.Functions.Like(product.Price.ToString(), $"%{searchText}%") ||
                                               EF.Functions.Like(product.Description, $"%{searchText}%"))
                                               .Sorting(sorting)
                                               .Paging(paging);
        } 
    }
}
