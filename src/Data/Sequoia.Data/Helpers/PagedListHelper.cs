using Sequoia.Data.Models;

namespace Sequoia.Data.Helpers
{
    public static class PagedListHelper
    {
        public static PagedWrapper<TSource> GetPagedWrapper<TSource>(int page, int limit, int count) 
            where TSource : class
        {
            var result = new PagedWrapper<TSource>
            {
                Page = page,
                PageSize = limit,
                ItemsTotal = count
            };

            // count  total pages
            var pageCount = (double)result.ItemsTotal / limit;
            result.PagesTotal = (int)Math.Ceiling(pageCount);

            return result;
        }

        public static int CountRowsToSkip(int page, int limit)
        {
            var skip = (page - 1) * limit;

            return skip;
        }
    }
}
