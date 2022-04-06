using GuguShop.GridFsApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoPractices.Services;

namespace GuguShop.GridFsApplication.Services;

public class BaseMongoClient: IBaseMongoClient
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    
    public BaseMongoClient(IOptions<MongoConfiguration> mongoConfiguration)
    {
        _client = new MongoClient(
            mongoConfiguration.Value.ConnectionString);
        _database = _client.GetDatabase(
            mongoConfiguration.Value.DefaultDatabaseName);
    }

    public MongoClient GetMongoClient()
    {
        return _client;
    }

    public IMongoDatabase GetMongoDatabase()
    {
        return _database;
    }

    public IMongoDatabase GetMongoDatabase(string databaseName)
    {
        return _client.GetDatabase(databaseName);
    }

    public IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class
    {
        return _database.GetCollection<TDocument>(collectionName);
    }
}