using MongoDB.Driver;
using Sequoia.Data.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Interfaces
{
    public interface IMongoRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        public IMongoContext MongoContext { get; }
        public IMongoCollection<TEntity> MongoCollection { get; }

        // TODO: move to IRepositoryBase ? 
        Task<TEntity> MarkAsDeletedAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> MarkAsRestoredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
