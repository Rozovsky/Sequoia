using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Infrastructure.Interfaces
{
    public interface IIngredientRepository
    {
        Task<Ingredient> CreateIngredientAsync(Ingredient obj, CancellationToken cancellationToken);
        Task<Ingredient> UpdateIngredientAsync(string id, Ingredient obj, CancellationToken cancellationToken);
        Task DeleteIngredientAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(CancellationToken cancellationToken);
        Task<PagedWrapper<Ingredient>> GetIngredientsPagedAsync(int page, int limit, CancellationToken cancellationToken);
        Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken);
    }
}
