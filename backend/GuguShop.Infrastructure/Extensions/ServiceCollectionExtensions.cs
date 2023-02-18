using System;
using GuguShop.Domain.Repositories;
using GuguShop.Domain.Ums;
using GuguShop.Infrastructure.Data;
using GuguShop.Infrastructure.Repositories;
using GuguShop.Infrastructure.UnitOfWork;
using GuguShop.Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;

namespace GuguShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupInfrastructure(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GuguDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            serviceCollection.AddTransient<ITagRepository, TagRepository>();
            serviceCollection.AddTransient<IFileRepository, FileRepository>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            serviceCollection.AddScoped<ICryptoService, CryptoService>();
            serviceCollection.AddScoped<ICustomJwtGenerator, CustomJwtGenerator>();
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IMongoFileService, MongoFileService>();
            return serviceCollection;
        }

        public static IServiceCollection SetupMiniProfiler(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                ((MemoryCacheStorage)options.Storage).CacheDuration = TimeSpan.FromMinutes(60);
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
                options.TrackConnectionOpenClose = true;
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;
                options.EnableMvcFilterProfiling = true;
                options.EnableMvcViewProfiling = true;
            });
            return serviceCollection;
        }
    }
}