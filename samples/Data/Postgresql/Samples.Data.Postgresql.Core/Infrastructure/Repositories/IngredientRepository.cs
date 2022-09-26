using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class IngredientRepository : PostgresRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient obj, CancellationToken cancellationToken)
        {
            return await base.CreateAsync(obj, cancellationToken);
        }

        public async Task<Ingredient> UpdateIngredientAsync(string id, Ingredient obj, CancellationToken cancellationToken)
        {
            return await base.UpdateAsync(c => c.Id == id, obj, cancellationToken);
        }

        public async Task DeleteIngredientAsync(string id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<PagedWrapper<Ingredient>> GetIngredientsPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            return await base.GetPagedAsync(page, limit, cancellationToken);
        }
    }
}