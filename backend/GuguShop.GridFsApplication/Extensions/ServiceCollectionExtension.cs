using GuguShop.GridFsApplication.Models;
using GuguShop.GridFsApplication.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuguShop.GridFsApplication.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection SetupMongoGridFs(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var mongoConfigSection = configuration.GetSection(nameof(MongoConfiguration));
        serviceCollection.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
        });
        serviceCollection.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
            o.MultipartBoundaryLengthLimit = int.MaxValue;
            o.MultipartHeadersCountLimit = int.MaxValue;
            o.MultipartHeadersLengthLimit = int.MaxValue;
        });
        serviceCollection.Configure<MongoConfiguration>(opt => configuration.GetSection(nameof(MongoConfiguration)));
        serviceCollection.AddSingleton<IBaseMongoClient>(builder =>
        {
            var connectionString = mongoConfigSection.GetSection("ConnectionString").Value;
            var databaseName = mongoConfigSection.GetSection("DefaultDatabaseName").Value;
            var client = new BaseMongoClient(connectionString, databaseName);
            return client;
        }); // must be singletones
        return serviceCollection;
    }
}