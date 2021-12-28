using System.Reflection;
using AutoMapper;
using GuguShop.Application.Interfaces;
using GuguShop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GuguShop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.SetupAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddScoped<IProductService, ProductService>();
            return serviceCollection;
        }

        private static IServiceCollection SetupAutoMapper(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.AddSingleton((sp) =>
            {
                var configuration = new MapperConfiguration(cfg => cfg.AddMaps(assembly));
                return configuration.CreateMapper();
            });

            return serviceCollection;
        }
    }
}