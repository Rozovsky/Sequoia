using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities
{
    public abstract class Multilingual : IMultilingual<Translation>
    {
        [BsonElement("translations")]
        public List<Translation> Translations { get; set; }
    }
}
