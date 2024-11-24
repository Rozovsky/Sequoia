using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories;

public class RecipeRepository(IApplicationDbContext dbContext)
    : PostgresRepository<Category>(dbContext), IRecipeRepository
{
    public Task<Recipe> CreateRecipeAsync(Recipe obj, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRecipeAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Recipe>> GetRecipesBatchAsync(string[] ids, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Paged<Recipe>> GetRecipesPagedAsync(int page, int limit, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> UpdateRecipeAsync(string id, Recipe obj, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}