using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Exceptions;

namespace Samples.Common.Application.Common.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeAsync(id, cancellationToken);

            if (recipe == null)
                throw new NotFoundException(nameof(Ingredient), id);

            return recipe;
        }
    }
}
