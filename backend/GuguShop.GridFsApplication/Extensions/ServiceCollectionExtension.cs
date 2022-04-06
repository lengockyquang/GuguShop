using GuguShop.GridFsApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoPractices.Services;

namespace GuguShop.GridFsApplication.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection SetupMongoGridFs(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IBaseMongoClient, BaseMongoClient>(); // must be singletones
        return serviceCollection;
    }
}