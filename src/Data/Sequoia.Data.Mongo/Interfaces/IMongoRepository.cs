using MongoDB.Driver;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Interfaces
{
    public interface IMongoRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        public IMongoContext MongoContext { get; }
        public IMongoCollection<TEntity> MongoCollection { get; }
    }
}
