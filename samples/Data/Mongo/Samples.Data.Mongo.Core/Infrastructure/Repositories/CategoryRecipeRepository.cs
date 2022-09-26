using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Extensions;
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

        public async Task DeleteCategoryRecipeAsync(string id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<PagedWrapper<CategoryRecipe>> GetCategoryRecipesPagedAsync(string categoryId, int page, int limit, CancellationToken cancellationToken)
        {
            var categoryRecipes = await MongoCollection
                .AsQueryable()
                .Where(c => c.CategoryId == categoryId)
                .ToPagedListAsync(page, limit, cancellationToken);

            return categoryRecipes;
        }
    }
}
