using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities;

public abstract class BaseEntity : IBaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public virtual string Id { get; set; }

    [BsonElement("is_deleted")]
    public virtual bool IsDeleted { get; set; }
}