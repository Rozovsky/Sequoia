using Sequoia.Data.Models;

namespace Sequoia.Data.Interfaces
{
    public interface IPagedQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Sort Sort { get; set; }
    }
}
