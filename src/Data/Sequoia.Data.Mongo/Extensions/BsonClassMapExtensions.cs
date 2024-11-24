using MongoDB.Bson.Serialization;
using System.Collections.Concurrent;

namespace Sequoia.Data.Mongo.Extensions;

public static class BsonClassMapExtensions
{
    private static readonly ConcurrentDictionary<Type, string> Cache = new();

    public static string GetCollectionName(this BsonClassMap classMap)
    {
        string result = null;

        if (Cache.TryGetValue(classMap.ClassType, out result))
            return result;
        else
            return classMap.ClassType.Name;
    }

    public static void SetCollectionName(this BsonClassMap classMap, string collectionName)
    {
        if (string.IsNullOrEmpty(collectionName))
            throw new InvalidOperationException("Collection name must be valid string.");

        Cache[classMap.ClassType] = collectionName;
    }
}