using GuguShop.Caching.Interfaces;
using GuguShop.Caching.Models;
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
            var cachingConfigs = new GuguCacheConfiguration();
            configuration.GetSection(nameof(GuguCacheConfiguration)).Bind(cachingConfigs);
            if(cachingConfigs.IsEnable)
            {
                var connectionString = cachingConfigs.RedisConnectionString;
                if (!string.IsNullOrEmpty(connectionString))
                {
                    var multiplexer = ConnectionMultiplexer.Connect(connectionString);
                    services.AddSingleton<IConnectionMultiplexer>(multiplexer);
                    services.AddScoped<IGuguCache, ExternalGuguCache>();
                }
            }
            return services;
        }
    }
}
