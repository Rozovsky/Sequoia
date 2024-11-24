using MediatR;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Queries.GetAllRecipes;

public class GetAllRecipesQuery : IRequest<List<RecipeVm>>
{
}