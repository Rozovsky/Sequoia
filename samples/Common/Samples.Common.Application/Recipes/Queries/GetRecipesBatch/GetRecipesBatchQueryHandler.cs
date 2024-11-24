using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesBatch;

public class GetRecipesBatchQueryHandler(
    IRecipeRepository recipeRepository,
    IMapper mapper) : IRequestHandler<GetRecipesBatchQuery, List<RecipeVm>>
{
    public async Task<List<RecipeVm>> Handle(GetRecipesBatchQuery request, CancellationToken cancellationToken)
    {
        var recipes = await recipeRepository.GetRecipesBatchAsync(request.Ids, cancellationToken);

        return mapper.Map<List<RecipeVm>>(recipes);
    }
}