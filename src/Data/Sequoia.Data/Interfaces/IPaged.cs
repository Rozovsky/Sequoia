namespace Sequoia.Data.Interfaces;

public interface IPaged<T>
{
    public long Page { get; set; }
    public long PageSize { get; set; }
    public long PagesTotal { get; set; }
    public List<T> Items { get; set; }
    public long ItemsTotal { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}