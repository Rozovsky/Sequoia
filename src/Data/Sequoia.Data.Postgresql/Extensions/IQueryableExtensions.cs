using Microsoft.EntityFrameworkCore;
using Sequoia.Data.Abstractions;

namespace Sequoia.Data.Postgresql.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedWrapper<T>> ToPagedWrapper<T>(
            this IQueryable<T> query, int page, int limit, CancellationToken cancellationToken = default)
            where T : class
        {
            var result = new PagedWrapper<T>
            {
                Page = page,
                PageSize = limit,
                ItemsTotal = query.Count()
            };

            var pageCount = (double)result.ItemsTotal / limit;
            result.PagesTotal = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * limit;

            result.Items = await query
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
