using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Options;

namespace Sequoia.Data.Mongo.Persistence;

public class MongoContext : IMongoContext
{
    private IMongoDatabase Database { get; set; }
    private MongoClient MongoClient { get; set; }

    public MongoContext(MongoConnectionOptions options)
    {
        MongoClient = new MongoClient(options.ConnectionString);
        Database = MongoClient.GetDatabase(options.Database);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return Database.GetCollection<T>(name);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return Database.GetCollection<T>(BsonClassMap.LookupClassMap(typeof(T)).GetCollectionName());
    }
}