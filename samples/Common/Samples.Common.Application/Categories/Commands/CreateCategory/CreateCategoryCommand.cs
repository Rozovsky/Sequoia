using MediatR;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.ViewModels;

namespace Samples.Common.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryVm>
    {
        public CategoryToCreateDto Dto { get; set; }
    }
}
