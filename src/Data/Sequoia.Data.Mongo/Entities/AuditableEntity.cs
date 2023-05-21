using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        [BsonElement("created_by")]
        public virtual string CreatedBy { get; set; }

        [BsonElement("created_at")]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [BsonElement("updated_by")]
        public virtual string UpdatedBy { get; set; }

        [BsonElement("updated_at")]
        public virtual DateTimeOffset? UpdatedAt { get; set; }
    }
}
