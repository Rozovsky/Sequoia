using MediatR;
using Samples.Common.Application.Recipes.Dtos;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommand : IRequest<RecipeVm>
{
    public RecipeToCreateDto Dto { get; set; }
}