using MediatR;
using Samples.Common.Application.Recipes.Dtos;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommand : IRequest<RecipeVm>
    {
        public string Id { get; set; }
        public RecipeToUpdateDto Dto { get; set; }
    }
}
