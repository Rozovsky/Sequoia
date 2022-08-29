using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Repositories
{
    public abstract class MongoRepository<TEntity> : IMongoRepository<TEntity> 
        where TEntity : class
    {
        public IMongoContext MongoContext { get; private set; }
        public IMongoCollection<TEntity> MongoCollection { get; private set; }

        protected MongoRepository(IMongoContext context)
        {
            MongoContext = context;
            MongoCollection = context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
        {
            await MongoCollection.InsertOneAsync(obj, cancellationToken: cancellationToken);
            
            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            await MongoCollection.ReplaceOneAsync(
                predicate, obj, new ReplaceOptions { IsUpsert = true }, cancellationToken: cancellationToken);

            return obj;
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            await MongoCollection.DeleteOneAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await MongoCollection
                .AsQueryable()
                .SingleOrDefaultAsync(predicate, cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var stores = await MongoCollection
                .AsQueryable()
                .ToListAsync(cancellationToken);

            return stores;
        }

        public virtual async Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await MongoCollection
                .AsQueryable()
                .ToPagedListAsync(page, limit, cancellationToken);

            return stores;
        }
    }
}
