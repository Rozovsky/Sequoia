using Microsoft.EntityFrameworkCore;
using Sequoia.Data.Helpers;
using Sequoia.Data.Models;

namespace Sequoia.Data.Postgresql.Extensions;

public static class IQueryableExtensions
{
    //public static async Task<PagedWrapper<TSource>> ToPagedListAsync<TSource>(
    //    this IQueryable<TSource> query, int page, int limit, CancellationToken cancellationToken = default)
    //    where TSource : class
    //{
    //    var result = new PagedWrapper<TSource>
    //    {
    //        Page = page,
    //        PageSize = limit,
    //        ItemsTotal = query.Count()
    //    };

    //    var pageCount = (double)result.ItemsTotal / limit;
    //    result.PagesTotal = (int)Math.Ceiling(pageCount);
    //    var skip = (page - 1) * limit;

    //    result.Items = await query
    //        .Skip(skip)
    //        .Take(limit)
    //        .ToListAsync(cancellationToken);

    //    return result;
    //}

    public static async Task<Paged<TSource>> ToPagedListAsync<TSource>(
        this IQueryable<TSource> source, int page, int limit, CancellationToken cancellationToken = default)
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