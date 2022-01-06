using RestApi.Infrastructure.Data.Repositories.Contracts;
using RestApi.Infrastructure.Data.Repositories.Core;
using RestApi.Domain;

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
    }
}
