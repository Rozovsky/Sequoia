using MongoDB.Driver;
using Sequoia.Data.Mongo.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Repositories
{
    public abstract class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected IMongoCollection<TEntity> _collection;

        protected MongoRepository(IMongoContext context)
        {
            _context = context;

            _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async virtual Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(obj, cancellationToken: cancellationToken);

            return obj;
        }

        public virtual async Task AddRangeAsync(ICollection<TEntity> documents, CancellationToken cancellationToken)
        {
            await _collection.InsertManyAsync(documents, cancellationToken: cancellationToken);
        }

        public async virtual Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            var result = await _collection.ReplaceOneAsync(predicate,
                obj,
                new ReplaceOptions { IsUpsert = true },
                cancellationToken: cancellationToken);

            //var result = await _collection.ReplaceOneAsync(
            //    Builders<TEntity>.Filter.Eq("_id", id), obj, cancellationToken: cancellationToken);

            if (result.IsAcknowledged)
                return obj;

            throw new Exception("Can't update record");
        }

        public async virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            _ = await _collection.DeleteOneAsync(predicate, cancellationToken);
        }

        public async virtual Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            string sortBy = null,
            bool isSortDesc = false,
            CancellationToken cancellationToken = default)
        {
            var collection = _collection
             .Find(Builders<TEntity>.Filter.Where(predicate));

            if (sortBy != null)
            {
                collection = (isSortDesc)
                    ? collection.Sort(Builders<TEntity>.Sort.Descending(sortBy))
                    : collection.Sort(Builders<TEntity>.Sort.Ascending(sortBy));
            }

            var result = await collection.FirstOrDefaultAsync(cancellationToken);

            //var collection = await _collection
            // .Find(Builders<TEntity>.Filter.Where(predicate))
            // .Sort(Builders<TEntity>.Sort.Descending("date"))
            // .FirstOrDefaultAsync(cancellationToken);

            return result;
        }

        public async virtual Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            var collection = await _collection.FindAsync(filter, cancellationToken: cancellationToken);

            return await collection.SingleOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public virtual async Task<List<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            string sortBy = null,
            bool isSortDesc = false,
            CancellationToken cancellationToken = default)
        {
            var collection = _collection
                .Find(Builders<TEntity>.Filter.Where(predicate));

            if (sortBy != null)
            {
                collection = (isSortDesc)
                    ? collection.Sort(Builders<TEntity>.Sort.Descending(sortBy))
                    : collection.Sort(Builders<TEntity>.Sort.Ascending(sortBy));
            }

            var result = await collection.ToListAsync(cancellationToken);

            return result;
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _collection.AsQueryable();
        }
    }
}
