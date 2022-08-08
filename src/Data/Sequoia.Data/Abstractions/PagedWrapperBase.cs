namespace Sequoia.Data.Abstractions
{
    public abstract class PagedWrapperBase
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PagesTotal { get; set; }
        public int ItemsTotal { get; set; }

        public bool HasPreviousPage
        {
            get { return Page > 1; }
        }

        public bool HasNextPage
        {
            get { return Page < PagesTotal; }
        }
    }
}
