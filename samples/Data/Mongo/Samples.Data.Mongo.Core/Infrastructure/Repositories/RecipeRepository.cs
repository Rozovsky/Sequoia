using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
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
    }
}
