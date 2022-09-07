using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Data.Mongo.Core.Infrastructure.Configurations;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Category> Categories { get; private set; }
        public IMongoCollection<Ingredient> Ingredients { get; private set; }
        public IMongoCollection<Recipe> Recipes { get; private set; }

        public ApplicationDbContext(IMongoContext context)
        {
            Categories = context.GetCollection<Category>(CategoryConfig.GetCollectionName());
            Ingredients = context.GetCollection<Ingredient>(IngredientConfig.GetCollectionName());
            Recipes = context.GetCollection<Recipe>(RecipeConfig.GetCollectionName());
        }
    }
}
