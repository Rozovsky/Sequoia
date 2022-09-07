using MongoDB.Driver;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Ingredient> Ingredients { get; }
        IMongoCollection<Recipe> Recipes { get; }
    }
}
