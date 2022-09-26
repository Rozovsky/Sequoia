using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class RecipeRepository : MongoRepository<Recipe>, IRecipeRepository
    {
        protected IMongoCollection<Recipe> _recipeCollection;

        public RecipeRepository(IMongoContext context) : base(context)
        {
            _recipeCollection = MongoContext.GetCollection<Recipe>();
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe obj, CancellationToken cancellationToken)
        {
            return await base.CreateAsync(obj, cancellationToken);
        }

        public async Task<Recipe> UpdateRecipeAsync(string id, Recipe obj, CancellationToken cancellationToken)
        {
            return await base.UpdateAsync(c => c.Id == id, obj, cancellationToken);
        }

        public async Task DeleteRecipeAsync(string id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task<PagedWrapper<Recipe>> GetRecipesPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            return await base.GetPagedAsync(page, limit, cancellationToken);
        }

        public async Task<Recipe> GetRecipeAsync(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }
    }
}
