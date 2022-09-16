using MongoDB.Bson.Serialization;
using System.Collections.Concurrent;

namespace Sequoia.Data.Mongo.Extensions
{
    public static class BsonClassMapExtensions
    {
        private static ConcurrentDictionary<Type, string> _cache = new ConcurrentDictionary<Type, string>();

        public static string GetCollectionName(this BsonClassMap classMap)
        {
            string result = null;

            if (_cache.TryGetValue(classMap.ClassType, out result))
                return result;
            else
                return classMap.ClassType.Name;
        }

        public static void SetCollectionName(this BsonClassMap classMap, string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
                throw new InvalidOperationException("Collection name must be valid string.");

            _cache[classMap.ClassType] = collectionName;
        }
    }
}
