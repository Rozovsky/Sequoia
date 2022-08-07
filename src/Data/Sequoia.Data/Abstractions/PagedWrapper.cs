using AutoMapper;

namespace Sequoia.Data.Abstractions
{
    [AutoMap(typeof(PagedWrapper<>))]
    public class PagedWrapper<TItem> : PagedWrapperBase 
        where TItem : class
    {
        public List<TItem> Items { get; set; }

        public PagedWrapper()
        {
            Items = new List<TItem>();
        }
    }
}
