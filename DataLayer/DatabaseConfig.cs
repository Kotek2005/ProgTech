using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataLayer.Repositories;

namespace DataLayer
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext (keeping for now as we might need it for migrations)
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories
            services.AddScoped<IProductRepository, LINQProductRepository>(); // LINQ to SQL

            return services;
        }
    }
} 