using MongoDB.Driver;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Repositories
{
    public class AuditableMultilingualMongoRepository<TEntity> : MultilingualMongoRepository<TEntity>, IMongoRepository<TEntity>
        where TEntity : class
    {
        private ICurrentUser CurrentUser { get; set; }

        protected AuditableMultilingualMongoRepository(IMongoContext context, ICurrentUser currentUser, string language = null)
            : base(context, currentUser.Language ?? language)
        {
            CurrentUser = currentUser;
        }

        private TEntity SetAuditableEntityValues(TEntity obj)
        {
            if (obj is not IAuditable)
                return obj;

            if (CurrentUser == null)
                throw new Exception("CurrentUser is not defined in the repository");

            var auditable = obj as IAuditable;

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

        public override async Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken)
        {
            obj = SetAuditableEntityValues(obj);

            await MongoCollection.InsertOneAsync(obj, cancellationToken: cancellationToken);

            return obj;
        }

        public override async Task<TEntity> Update(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            obj = SetAuditableEntityValues(obj);

            await MongoCollection.ReplaceOneAsync(
                predicate, obj, new ReplaceOptions { IsUpsert = true }, cancellationToken: cancellationToken);

            return obj;
        }
    }
}
