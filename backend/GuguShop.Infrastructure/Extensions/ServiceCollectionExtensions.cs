using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Data;
using GuguShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuguShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GuguDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            return serviceCollection;
        }
    }
}