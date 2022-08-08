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
                PageNumber = page,
                PageSize = limit,
                TotalCount = query.Count()
            };

            var pageCount = (double)result.TotalCount / limit;
            result.TotalPages = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * limit;

            result.Items = await query
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return result;
        }

        //public static PagedWrapper<U> ToCastedPagedWrapper<T, U>(this IQueryable<T> query, IMapper mapper, int page, int pageSize) where U : class
        //{
        //    var result = new PagedWrapper<U>
        //    {
        //        PageNumber = page,
        //        PageSize = pageSize,
        //        TotalCount = query.Count()
        //    };

        //    var pageCount = (double)result.TotalCount / pageSize;
        //    result.TotalPages = (int)Math.Ceiling(pageCount);

        //    var skip = (page - 1) * pageSize;

        //    result.Items = query
        //        .Skip(skip)
        //        .Take(pageSize)
        //        .ProjectTo<U>(mapper.ConfigurationProvider)
        //        .ToList();

        //    return result;
        //}
    }
}
