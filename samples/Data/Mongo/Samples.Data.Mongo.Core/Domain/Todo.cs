using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Entities;

namespace Samples.Data.Mongo.Core.Domain
{
    public class Todo : IMultilingual
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<Translation> Translations { get; set; }
        IEnumerable<ITranslation> IMultilingual.Translations { get; set; }

        //public List<Translation> Translations { get; set; }
    }
}
