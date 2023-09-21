namespace Sequoia.Data.Models
{
    public class Paged<T> where T : class
    {
        public long Page { get; set; }
        public long PageSize { get; set; }
        public long PagesTotal { get; set; }
        public List<T> Items { get; set; }
        public long ItemsTotal { get; set; }

        public bool HasPreviousPage
        {
            get { return Page > 1; }
        }

        public bool HasNextPage
        {
            get { return Page < PagesTotal; }
        }

        public Paged()
        {
            Items = new List<T>();
        }
    }
}
