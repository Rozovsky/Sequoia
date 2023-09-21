using MongoDB.Driver;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;

namespace Sequoia.Data.Mongo.Interfaces
{
    public interface IMongoRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        public IMongoContext MongoContext { get; }
        public IMongoCollection<TEntity> MongoCollection { get; }
        Task<Paged<TEntity>> GetPaged(FilterDefinition<TEntity> filter, SortDefinition<TEntity> sort, int page, int pageSize, CancellationToken cancellationToken = default);
    }
}
