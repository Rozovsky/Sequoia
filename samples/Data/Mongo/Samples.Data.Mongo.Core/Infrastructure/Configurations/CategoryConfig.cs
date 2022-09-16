using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Samples.Common.Domain.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class CategoryConfig : IMongoEntityConfig
    {
        public void Configure()
        {
            // https://mongodb.github.io/mongo-csharp-driver/2.0/reference/bson/mapping/
            BsonClassMap.RegisterClassMap<Category>(cm =>
            {
                cm.SetCollectionName("categories");
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.MapMember(c => c.Name).SetElementName("name");
                cm.MapMember(c => c.Recipes).SetElementName("recipes");
            });
        }
    }
}
