using AutoMapper;
using Sequoia.Data.Abstractions;

namespace Sequoia.Data.Models
{
    [AutoMap(typeof(PagedWrapper<>))]
    public class PagedWrapper<TItem> : PagedWrapperBase // TODO: move to implementation
        where TItem : class
    {
        public List<TItem> Items { get; set; }

        public PagedWrapper()
        {
            Items = new List<TItem>();
        }
    }
}
