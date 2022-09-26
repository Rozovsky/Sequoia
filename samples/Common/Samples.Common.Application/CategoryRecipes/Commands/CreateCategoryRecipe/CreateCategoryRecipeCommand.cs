using MediatR;
using Samples.Common.Application.CategoryRecipes.Dtos;
using Samples.Common.Application.CategoryRecipes.ViewModels;

namespace Samples.Common.Application.CategoryRecipes.Commands.CreateCategoryRecipe
{
    public class CreateCategoryRecipeCommand : IRequest<CategoryRecipeVm>
    {
        public CategoryRecipeToCreateDto Dto { get; set; }
    }
}
