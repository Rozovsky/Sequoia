using AutoMapper;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;

namespace Sequoia.Data.Mongo.ViewModels;

[AutoMap(typeof(Paged<>))]
public class PagedVm<T> : IPaged<T> where T : class
{
    public long Page { get; set; }
    public long PageSize { get; set; }
    public long PagesTotal { get; set; }
    public List<T> Items { get; set; }
    public long ItemsTotal { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}