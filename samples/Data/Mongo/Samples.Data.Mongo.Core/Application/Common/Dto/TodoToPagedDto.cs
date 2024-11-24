using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Common.Dto;

public class TodoToPagedDto : IPagedQuery
{
    public TodoToPagedFilter Filter { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public Sort Sort { get; set; }

    public class TodoToPagedFilter
    {
        public long? UserId { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }
    }
}