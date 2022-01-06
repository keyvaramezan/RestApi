using RestApi.Domain.Data.Core;

namespace RestApi.Domain
{
    public class Image : Entity<int>
    {
        public string? Name { get; set; }
        public int ProductId { get; set; }
    }
}
