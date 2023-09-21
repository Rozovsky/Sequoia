using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Categories.Queries.GetCategoriesPaged
{
    public class GetCategoriesPagedQuery : IRequest<Paged<CategoryVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
