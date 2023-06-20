using MongoDB.Bson.Serialization.Attributes;
using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Mongo.Entities
{
    public class Translation : ITranslation
    {
        [BsonElement("language")]
        public string Language { get; set; }

        [BsonElement("field")]
        public string Field { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }
    }


    public class Test
    {
        public class Entity : IMultilingual
        {
            public int Id { get; set; }
            //public List<Translation> Translations { get; set; }
            public IEnumerable<ITranslation> Translations { get; set; }
        }

        private void Tess() 
        {
            ITranslation tra = new Translation();

            IEnumerable<ITranslation> translations = new List<Translation>();
        }
    }

    
}
