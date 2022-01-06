using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Service;
using RestApi.Application.Service.Core;
using RestApi.Infrastructure.Data;
using RestApi.Infrastructure.Data.Repositories;
using RestApi.Infrastructure.Data.Repositories.Contracts;
using System.Reflection;

namespace RestApi.Application.ServiceExtension
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
            services
                    .AddPersistance(configuration)
                    .AddRepository()
                    .AddEndpointsApiExplorer()
                    .AddSwaggerGen()
                    .AddTestService()
                    .AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;

        }
        private static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddDbContext<CatalogContext>(builder =>
            {
                SqlConnectionStringBuilder sqlCnnStrBuilder =
                    new SqlConnectionStringBuilder(configuration.GetConnectionString("Catalog"));
                sqlCnnStrBuilder.Password = configuration["Password"];
                builder.UseSqlServer(sqlCnnStrBuilder.ConnectionString);
            });

        }
        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            return services
                           .AddTransient<IProductRepository, SqlProductRepository>()
                           .AddTransient<IImageRepository, SqlImageRepository>();
        }
        private static IServiceCollection AddTestService(this IServiceCollection services)
        {
            return services.AddTransient<IService, TestService>();
        }
    }
}
