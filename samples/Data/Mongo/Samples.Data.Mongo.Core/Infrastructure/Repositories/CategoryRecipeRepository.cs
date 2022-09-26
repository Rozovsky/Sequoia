using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class CategoryRecipeRepository : MongoRepository<CategoryRecipe>, ICategoryRecipeRepository
    {
        protected IMongoCollection<CategoryRecipe> _categoryRecipeCollection;

        public CategoryRecipeRepository(IMongoContext context) : base(context)
        {
            _categoryRecipeCollection = MongoContext.GetCollection<CategoryRecipe>();
        }

        public async Task<CategoryRecipe> CreateCategoryRecipeAsync(CategoryRecipe obj, CancellationToken cancellationToken)
        {
            return await base.CreateAsync(obj, cancellationToken);
        }

        public async Task<CategoryRecipe> UpdateCategoryRecipeAsync(string id, CategoryRecipe obj, CancellationToken cancellationToken)
        {
            return await base.UpdateAsync(c => c.Id == id, obj, cancellationToken);
        }

        public async Task DeleteCategoryRecipeAsync(string id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<CategoryRecipe>> GetAllCategoryRecipeAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task<PagedWrapper<CategoryRecipe>> GetCategoryRecipePagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            return await base.GetPagedAsync(page, limit, cancellationToken);
        }

        public async Task<CategoryRecipe> GetCategoryRecipeAsync(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }
    }
}
