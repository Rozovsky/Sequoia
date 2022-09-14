using MediatR;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public CategoryToCreateDto Dto { get; set; }
    }
}
