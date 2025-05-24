using GuguShop.GridFsApplication.Models;
using GuguShop.GridFsApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuguShop.GridFsApplication.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection SetupMongoGridFs(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var mongoConfigSection = configuration.GetSection(nameof(MongoConfiguration));
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