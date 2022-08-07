using AutoMapper;

namespace Sequoia.Data.Abstractions
{
    [AutoMap(typeof(PagedWrapper<>))]
    public class PagedWrapper<TItem> : PagedWrapperBase 
        where TItem : class
    {
        public List<TItem> Items { get; set; }

        public int FirstRowOnPage
        {
            get 
            { 
                return (PageNumber - 1) * PageSize + 1;
            }
        }

        public int LastRowOnPage
        {
            get 
            { 
                return Math.Min(PageNumber * PageSize, TotalCount);
            }
        }

        public PagedWrapper()
        {
            Items = new List<TItem>();
        }
    }
}
