using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Exceptions;
using Sequoia.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Repositories
{
    public abstract class MongoRepository<TEntity> : IMongoRepository<TEntity> 
        where TEntity : class
    {
        public IMongoContext MongoContext { get; private set; }
        public IMongoCollection<TEntity> MongoCollection { get; private set; }

        private ICurrentUser CurrentUser { get; set; }

        protected MongoRepository(IMongoContext context, ICurrentUser currentUser = null)
        {
            MongoContext = context;
            CurrentUser = currentUser;            
            MongoCollection = context.GetCollection<TEntity>(
                BsonClassMap.LookupClassMap(typeof(TEntity)).GetCollectionName());
        }

        private TEntity SetAuditableEntityValues(TEntity obj)
        {
            if (obj is not IAuditableEntity)
                return obj;

            if (CurrentUser == null)
                throw new Exception("CurrentUser is not defined in the repository");

            var auditable = obj as IAuditableEntity;

            if (auditable.CreatedAt == null)
            {
                auditable.CreatedBy = CurrentUser.ProfileId;
                auditable.CreatedAt = DateTimeOffset.UtcNow;
            }
            else
            {
                auditable.UpdatedBy = CurrentUser.ProfileId;
                auditable.UpdatedAt = DateTimeOffset.UtcNow;
            }

            return obj;
        }

        private TEntity SetDeletedEntityValue(TEntity obj, bool isDeleted)
        {
            if (obj is not IBaseEntity)
                throw new Exception("The specified entry does not implement the IBaseEntity interface");

            var baseEntity = obj as IBaseEntity;

            baseEntity.IsDeleted = isDeleted;

            return obj;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
        {
            obj = SetAuditableEntityValues(obj);

            await MongoCollection.InsertOneAsync(obj, cancellationToken: cancellationToken);
            
            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            obj = SetAuditableEntityValues(obj);

            await MongoCollection.ReplaceOneAsync(
                predicate, obj, new ReplaceOptions { IsUpsert = true }, cancellationToken: cancellationToken);

            return obj;
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            await MongoCollection.DeleteOneAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity> MarkAsDeletedAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var obj = await GetAsync(predicate, cancellationToken);

            if (obj == null)
                throw new NotFoundException("No matches found for the specified expression");

            obj = SetDeletedEntityValue(obj, true);

            return await UpdateAsync(predicate, obj, cancellationToken);
        }

        public virtual async Task<TEntity> MarkAsRestoredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var obj = await GetAsync(predicate, cancellationToken);

            if (obj == null)
                throw new NotFoundException("No matches found for the specified expression");

            obj = SetDeletedEntityValue(obj, false);

            return await UpdateAsync(predicate, obj, cancellationToken);
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
            var entities = await MongoCollection
                .AsQueryable()
                .ToListAsync(cancellationToken);

            return entities;
        }

        public virtual async Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            var entities = await MongoCollection
                .AsQueryable()
                .ToPagedListAsync(page, limit, cancellationToken);

            return entities;
        }
    }
}
