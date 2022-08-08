using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Abstractions;

namespace Sequoia.Data.Mongo.Extensions
{
    public static class IMongoQueryableExtensions
    {
        public static async Task<PagedWrapper<TSource>> ToPagedListAsync<TSource>(
            this IMongoQueryable<TSource> source, int page, int limit, CancellationToken cancellationToken = default)
            where TSource : class
        {
            var result = new PagedWrapper<TSource>
            {
                Page = page,
                PageSize = limit,
                ItemsTotal = source.Count()
            };

            var pageCount = (double)result.ItemsTotal / limit;
            result.PagesTotal = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * limit;

            result.Items = await source
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
