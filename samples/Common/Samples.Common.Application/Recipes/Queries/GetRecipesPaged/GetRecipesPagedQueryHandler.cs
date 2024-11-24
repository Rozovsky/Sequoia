using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesPaged;

public class GetRecipesPagedQueryHandler(
    IRecipeRepository recipeRepository,
    IMapper mapper) : IRequestHandler<GetRecipesPagedQuery, Paged<RecipeVm>>
{
    public async Task<Paged<RecipeVm>> Handle(GetRecipesPagedQuery request, CancellationToken cancellationToken)
    {
        var recipes = await recipeRepository.GetRecipesPagedAsync(
            request.Page, request.Limit, cancellationToken);

        return mapper.Map<Paged<RecipeVm>>(recipes);
    }
}