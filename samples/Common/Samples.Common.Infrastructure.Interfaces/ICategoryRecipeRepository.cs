using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Infrastructure.Interfaces
{
    public interface ICategoryRecipeRepository
    {
        Task<CategoryRecipe> CreateCategoryRecipeAsync(CategoryRecipe obj, CancellationToken cancellationToken);
        Task DeleteCategoryRecipeAsync(string id, CancellationToken cancellationToken);
        Task<PagedWrapper<CategoryRecipe>> GetCategoryRecipesPagedAsync(string categoryId, int page, int limit, CancellationToken cancellationToken);
    }
}
