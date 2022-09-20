using MediatR;
using Samples.Common.Application.Categories.ViewModels;

namespace Samples.Common.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public string Id { get; set; }
    }
}
