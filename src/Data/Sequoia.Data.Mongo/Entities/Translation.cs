using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities;

public class Translation : ITranslation
{
    [BsonElement("language")]
    public string Language { get; set; }

    [BsonElement("field")]
    public string Field { get; set; }

    [BsonElement("value")]
    public string Value { get; set; }
}