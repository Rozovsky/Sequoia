using MongoDB.Driver;

namespace Sequoia.Data.Mongo.Interfaces
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
        IMongoCollection<T> GetCollection<T>();
    }
}
