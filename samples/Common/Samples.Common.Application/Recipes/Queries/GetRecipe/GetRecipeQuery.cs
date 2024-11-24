using MediatR;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQuery : IRequest<RecipeVm>
{
    public string Id { get; set; }
}