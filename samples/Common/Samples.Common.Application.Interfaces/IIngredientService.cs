using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken);
    }
}
