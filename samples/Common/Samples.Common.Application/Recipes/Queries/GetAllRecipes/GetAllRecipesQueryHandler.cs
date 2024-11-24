using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Queries.GetAllRecipes;

public class GetAllRecipesQueryHandler(
    IRecipeRepository recipeRepository,
    IMapper mapper) : IRequestHandler<GetAllRecipesQuery, List<RecipeVm>>
{
    public async Task<List<RecipeVm>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await recipeRepository.GetAllRecipesAsync(cancellationToken);

        return mapper.Map<List<RecipeVm>>(recipes);
    }
}