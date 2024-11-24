using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Exceptions;

namespace Samples.Common.Application.Common.Services;

public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
{
    public async Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken)
    {
        var recipe = await recipeRepository.GetRecipeAsync(id, cancellationToken);

        if (recipe == null)
            throw new NotFoundException(nameof(Ingredient), id);

        return recipe;
    }
}