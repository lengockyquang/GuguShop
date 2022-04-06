using MongoDB.Driver;

namespace MongoPractices.Services
{
    public interface IBaseMongoClient
    {
        MongoClient GetMongoClient();
        IMongoDatabase GetMongoDatabase();
        IMongoDatabase GetMongoDatabase(string databaseName);

        IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class;
    }
}