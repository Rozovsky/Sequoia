using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Exceptions;
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
            MongoCollection = context.GetCollection<TEntity>(
                BsonClassMap.LookupClassMap(typeof(TEntity)).GetCollectionName());
        }

        private TEntity SetDeletedEntityValue(TEntity obj, bool isDeleted)
        {
            if (obj is not IBaseEntity)
                throw new Exception("The specified entry does not implement the IBaseEntity interface");

            var baseEntity = obj as IBaseEntity;

            baseEntity.IsDeleted = isDeleted;

            return obj;
        }

        public virtual async Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken)
        {
            await MongoCollection.InsertOneAsync(obj, cancellationToken: cancellationToken);
            
            return obj;
        }

        public virtual async Task<TEntity> Update(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            await MongoCollection.ReplaceOneAsync(
                predicate, obj, new ReplaceOptions { IsUpsert = true }, cancellationToken: cancellationToken);

            return obj;
        }

        public virtual async Task Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            await MongoCollection.DeleteOneAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity> MarkAsDeleted(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var obj = await Get(predicate, cancellationToken);

            if (obj == null)
                throw new NotFoundException("No matches found for the specified expression");

            obj = SetDeletedEntityValue(obj, true);

            return await Update(predicate, obj, cancellationToken);
        }

        public virtual async Task<TEntity> MarkAsRestored(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var obj = await Get(predicate, cancellationToken);

            if (obj == null)
                throw new NotFoundException("No matches found for the specified expression");

            obj = SetDeletedEntityValue(obj, false);

            return await Update(predicate, obj, cancellationToken);
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await MongoCollection
                .AsQueryable()
                .SingleOrDefaultAsync(predicate, cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await MongoCollection
                .AsQueryable()
                .ToListAsync(cancellationToken);

            return entities;
        }

        public virtual async Task<Paged<TEntity>> GetPaged(
          FilterDefinition<TEntity> filter, SortDefinition<TEntity> sort, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            return await MongoCollection.AsPagedResult(filter, sort, page, pageSize);
        }
    }
}
