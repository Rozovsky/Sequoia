using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
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
    }
}
