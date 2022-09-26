using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken);
    }
}
