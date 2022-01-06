using RestApi.Domain;

namespace RestApi.Infrastructure.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product, int>
    {
        //Task<IEnumerable<Product>> GetByMinPrice(int minPrice);
        //Task<IEnumerable<Product>> GetByMaxPrice(int maxPrice);
        //Task<IEnumerable<Product>> GetByRangePrice(int minPrice, int maxPrice);
        //Task<IEnumerable<Product>> GetByQuery(int minPrice, int maxPrice);
    }
}
