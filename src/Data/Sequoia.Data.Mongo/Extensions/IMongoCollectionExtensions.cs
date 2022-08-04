using MongoDB.Driver;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Extensions
{
    public static class IMongoCollectionExtensions
    {
        public static async Task<TEntity> SingleOrDefaultAsync<TEntity>(
            this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            var result = await collection.FindAsync(filter, cancellationToken: cancellationToken);
            var entity = await result.SingleOrDefaultAsync(cancellationToken);

            return entity;
        }

        // TODO: add order by extension

        public static async Task<TEntity> FirstOrDefaultAsync<TEntity, TSortKey>(
            this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSortKey>> sortKey, CancellationToken cancellationToken = default)
        {
            /*var filter = Builders<TEntity>.Filter.Where(predicate);
            var sort = Builders<TEntity>.Sort.Descending(sortKey as FieldDefinition<TEntity>);
            var result = await collection.FindAsync(filter, sort, cancellationToken: cancellationToken);
            var entity = await result.SingleOrDefaultAsync(cancellationToken);


            var collection2 = _collection
                .Find(Builders<TEntity>.Filter.Where(predicate));

            if (sortBy != null)
            {
                collection = (isSortDesc)
                    ? collection.Sort(Builders<TEntity>.Sort.Descending(sortBy))
                    : collection.Sort(Builders<TEntity>.Sort.Ascending(sortBy));
            }

            var result2 = await collection.FirstOrDefaultAsync(cancellationToken);*/

            var entity = await collection
             .Find(Builders<TEntity>.Filter.Where(predicate))
             .Sort(Builders<TEntity>.Sort.Descending(sortKey as FieldDefinition<TEntity>))
             .FirstOrDefaultAsync(cancellationToken);

            return entity;
        }        
    }
}
