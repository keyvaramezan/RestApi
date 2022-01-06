using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Domain;

namespace RestApi.Infrastructure.Data.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        private const string Schema = "Catalog";
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image", Schema);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseHiLo("ProductSeq", Schema);
            builder.Property(m => m.Name).IsRequired().IsUnicode().HasMaxLength(200);
        }
    }
}