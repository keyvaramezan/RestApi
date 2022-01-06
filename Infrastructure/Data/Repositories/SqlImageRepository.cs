using RestApi.Infrastructure.Data.Repositories.Contracts;
using RestApi.Infrastructure.Data.Repositories.Core;
using RestApi.Domain;

namespace RestApi.Infrastructure.Data.Repositories
{
    public class SqlImageRepository : SqlRepository<Image, int>, IImageRepository
    {
        public SqlImageRepository(CatalogContext context) : base(context)
        {
        }
    }
}
