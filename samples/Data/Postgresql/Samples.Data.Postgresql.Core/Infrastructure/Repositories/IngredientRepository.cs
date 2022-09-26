using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class IngredientRepository : PostgresRepository<Category>, IIngredientRepository
    {
        public IngredientRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Ingredient> CreateIngredientAsync(Ingredient obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIngredientAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PagedWrapper<Ingredient>> GetIngredientsPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> UpdateIngredientAsync(string id, Ingredient obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}