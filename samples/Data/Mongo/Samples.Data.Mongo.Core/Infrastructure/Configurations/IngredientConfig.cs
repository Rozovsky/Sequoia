using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Samples.Common.Domain.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class IngredientConfig : IMongoEntityConfig
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<Ingredient>(cm =>
            {
                cm.SetCollectionName("ingredients");
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.MapMember(c => c.Name).SetElementName("name");
                cm.MapMember(c => c.ImageUrl).SetElementName("image_url");
            });
        }
    }
}
