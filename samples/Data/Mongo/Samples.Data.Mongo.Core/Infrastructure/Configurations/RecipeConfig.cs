using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Samples.Common.Domain.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class RecipeConfig : IMongoEntityConfig
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<Recipe>(cm =>
            {
                cm.SetCollectionName("recipes");
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.MapMember(c => c.Name).SetElementName("name");
                cm.MapMember(c => c.ImageUrl).SetElementName("image_url");
                cm.MapMember(c => c.Description).SetElementName("description");
                cm.MapMember(c => c.Rating).SetElementName("rating");
                cm.MapMember(c => c.Ingredients).SetElementName("ingredients");
            });
        }
    }
}
