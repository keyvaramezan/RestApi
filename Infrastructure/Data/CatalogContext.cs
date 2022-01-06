using Microsoft.EntityFrameworkCore;
using RestApi.Infrastructure.Data.Config;
using RestApi.Domain;

namespace RestApi.Infrastructure.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.Entity<Product>()
                        .HasMany(p => p.Images)
                        .WithOne()
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                    

        }

        DbSet<Product> Products { get; set; }
        DbSet<Image> Images { get; set; }
    }
}