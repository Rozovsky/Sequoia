using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Samples.Common.Domain.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class CategoryRecipeConfig : IMongoEntityConfig
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<CategoryRecipe>(cm =>
            {
                cm.SetCollectionName("category_recipes");
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.MapMember(c => c.CategoryId).SetElementName("category_id");
                cm.MapMember(c => c.RecipeId).SetElementName("recipe_id");
            });
        }
    }
}
