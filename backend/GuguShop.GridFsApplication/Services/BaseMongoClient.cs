using GuguShop.GridFsApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GuguShop.GridFsApplication.Services;

public class BaseMongoClient: IBaseMongoClient
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    
    public BaseMongoClient(string connectionString, string defaultDatabaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(defaultDatabaseName);
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