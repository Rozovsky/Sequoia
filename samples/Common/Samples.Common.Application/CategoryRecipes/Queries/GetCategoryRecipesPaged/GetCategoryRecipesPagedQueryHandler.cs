using AutoMapper;
using MediatR;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.CategoryRecipes.Queries.GetCategoryRecipesPaged;

public class GetCategoryRecipesPagedQueryHandler(
    ICategoryRecipeRepository categoryRecipeRepository,
    IRecipeRepository recipeRepository,
    IMapper mapper)
    : IRequestHandler<GetCategoryRecipesPagedQuery, Paged<CategoryRecipeVm>>
{
    public async Task<Paged<CategoryRecipeVm>> Handle(GetCategoryRecipesPagedQuery request, CancellationToken cancellationToken)
    {
        var categoryRecipes = await categoryRecipeRepository.GetCategoryRecipesPagedAsync(
            request.CategoryId, request.Page, request.Limit, cancellationToken);

        var recipesIds = categoryRecipes.Items.Select(x => x.RecipeId).ToList();
        var recipes = await recipeRepository.GetRecipesBatchAsync(recipesIds.ToArray(), cancellationToken);

        categoryRecipes.Items.ForEach(c => c.Recipe = recipes.FirstOrDefault(p => p.Id == c.RecipeId));

        return mapper.Map<Paged<CategoryRecipeVm>>(categoryRecipes);
    }
}