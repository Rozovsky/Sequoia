using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class IngredientRepository : MongoRepository<Ingredient>, IIngredientRepository
    {
        protected IMongoCollection<Ingredient> _ingredientCollection;

        public IngredientRepository(IMongoContext context) : base(context)
        {
            _ingredientCollection = MongoContext.GetCollection<Ingredient>();
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

        public async Task<PagedWrapper<Ingredient>> GetIngredientsPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            return await base.GetPagedAsync(page, limit, cancellationToken);
        }

        public async Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }
    }
}
