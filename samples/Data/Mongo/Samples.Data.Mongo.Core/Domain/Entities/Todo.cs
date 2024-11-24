using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Mongo.Entities;

namespace Samples.Data.Mongo.Core.Domain.Entities;

public class Todo : AuditableMultilingual //Auditable, IMultilingual<Translation> //Multilingual
{
    //[BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    //public string Id { get; set; }

    [BsonElement("user_id")]
    public long UserId { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("completed")]
    public bool Completed { get; set; }

    //[BsonElement("translations")]
    //public List<Translation> Translations { get; set; }
}