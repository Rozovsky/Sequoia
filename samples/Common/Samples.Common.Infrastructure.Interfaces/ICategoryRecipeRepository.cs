using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Infrastructure.Interfaces
{
    public interface ICategoryRecipeRepository
    {
        Task<CategoryRecipe> CreateCategoryRecipeAsync(CategoryRecipe obj, CancellationToken cancellationToken);
        Task<CategoryRecipe> UpdateCategoryRecipeAsync(string id, CategoryRecipe obj, CancellationToken cancellationToken);
        Task DeleteCategoryRecipeAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<CategoryRecipe>> GetAllCategoryRecipeAsync(CancellationToken cancellationToken);
        Task<PagedWrapper<CategoryRecipe>> GetCategoryRecipePagedAsync(int page, int limit, CancellationToken cancellationToken);
        Task<CategoryRecipe> GetCategoryRecipeAsync(string id, CancellationToken cancellationToken);
    }
}
