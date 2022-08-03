namespace Sequoia.Data.Abstractions
{
    // TODO: refactor
    public class PagedWrapper<T> : ListWrapperBase where T : class
    {
        public List<T> Items { get; set; }

        public int FirstRowOnPage
        {
            get { return (PageNumber - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(PageNumber * PageSize, TotalCount); }
        }

        public PagedWrapper()
        {
            Items = new List<T>();
        }
    }
}
