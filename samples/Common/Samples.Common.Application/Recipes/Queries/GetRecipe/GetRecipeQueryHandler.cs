using AutoMapper;
using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryHandler(
    IRecipeService recipeService,
    IMapper mapper) : IRequestHandler<GetRecipeQuery, RecipeVm>
{
    public async Task<RecipeVm> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await recipeService.GetRecipeAsync(request.Id, cancellationToken);

        return mapper.Map<RecipeVm>(recipe);
    }
}