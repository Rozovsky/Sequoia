using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities
{
    public abstract class AuditableMultilingual : Auditable, IMultilingual<Translation>
    {
        [BsonElement("translations")]
        public List<Translation> Translations { get; set; }
    }
}
