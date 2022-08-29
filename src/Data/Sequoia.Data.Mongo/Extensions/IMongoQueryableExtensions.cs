using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Helpers;
using Sequoia.Data.Models;

namespace Sequoia.Data.Mongo.Extensions
{
    public static class IMongoQueryableExtensions
    {
        public static async Task<PagedWrapper<TSource>> ToPagedListAsync<TSource>(
            this IMongoQueryable<TSource> source, int page, int limit, CancellationToken cancellationToken = default)
            where TSource : class
        {
            var result = PagedListHelper.GetPagedWrapper<TSource>(page, limit, source.Count());
            var skip = PagedListHelper.CountRowsToSkip(page, limit);

            result.Items = await source
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
