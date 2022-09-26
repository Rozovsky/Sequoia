using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Infrastructure.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateRecipeAsync(Recipe obj, CancellationToken cancellationToken);
        Task<Recipe> UpdateRecipeAsync(string id, Recipe obj, CancellationToken cancellationToken);
        Task DeleteRecipeAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken);
        Task<PagedWrapper<Recipe>> GetRecipesPagedAsync(int page, int limit, CancellationToken cancellationToken);
        Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken);
        Task<List<Recipe>> GetRecipesBatchAsync(string[] ids, CancellationToken cancellationToken);
    }
}
