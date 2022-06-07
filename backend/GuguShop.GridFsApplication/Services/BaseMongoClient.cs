using GuguShop.GridFsApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace GuguShop.GridFsApplication.Services;

public class BaseMongoClient: IBaseMongoClient
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly GridFSBucketOptions _bucketOptions;
    private const int ChunkSizeBytes = 1048576;
    private const string DefaultBucketName = "sample";
    public BaseMongoClient(string connectionString, string defaultDatabaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(defaultDatabaseName);
        _bucketOptions = new GridFSBucketOptions
        {
            BucketName = DefaultBucketName,
            ChunkSizeBytes = ChunkSizeBytes, // 1MB
            WriteConcern = WriteConcern.WMajority,
            ReadPreference = ReadPreference.Secondary
        };
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

    public async Task<ObjectId> UploadFromBytesAsync(string fileName, byte[] bytes, CancellationToken cancellationToken = default)
    {
        var bucket = new GridFSBucket(GetMongoDatabase(), _bucketOptions);
        return await bucket.UploadFromBytesAsync(fileName, bytes, null, cancellationToken);
    }
}