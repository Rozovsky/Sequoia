using MongoDB.Driver;
using Samples.Common.Domain.Entities;
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
            Categories = context.GetCollection<Category>();
            Ingredients = context.GetCollection<Ingredient>();
            Recipes = context.GetCollection<Recipe>();
        }
    }
}
