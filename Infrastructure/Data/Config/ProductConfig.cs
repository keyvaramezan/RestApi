using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Domain;

namespace RestApi.Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        private const string Schema = "Catalog";
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", Schema);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseHiLo("ProductSeq", Schema);
            builder.Property(m => m.Name).IsRequired().IsUnicode().HasMaxLength(200);
            builder.Property(m => m.Description).IsRequired(false).IsUnicode().HasMaxLength(500);
        }
    }
}