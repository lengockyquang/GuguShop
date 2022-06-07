using MongoDB.Bson;
using MongoDB.Driver;

namespace GuguShop.GridFsApplication.Services
{
    public interface IBaseMongoClient
    {
        MongoClient GetMongoClient();
        IMongoDatabase GetMongoDatabase();
        IMongoDatabase GetMongoDatabase(string databaseName);

        IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class;
        Task<ObjectId> UploadFromBytesAsync(string fileName, byte[] bytes, CancellationToken cancellationToken = default);
    }
}