using MediatR;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.ViewModels;

namespace Samples.Common.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryVm>
{
    public string Id { get; set; }
    public CategoryToUpdateDto Dto { get; set; }
}