using GuguShop.Caching.Interfaces;
using GuguShop.Caching.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace GuguShop.Caching.Extensions
{
    public static class SetupCachingExtensions
    {
        public static IServiceCollection SetupCaching(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure other services up here
            var multiplexer = ConnectionMultiplexer.Connect(configuration.GetSection("RedisConnectionString").Value);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);
            services.AddScoped<IGuguCache, ExternalGuguCache>();
            return services;
        }
    }
}
