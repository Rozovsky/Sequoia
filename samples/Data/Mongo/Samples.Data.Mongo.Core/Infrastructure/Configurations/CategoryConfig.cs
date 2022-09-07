namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class CategoryConfig
    {
        private const string _collectionName = "categories";

        public static string GetCollectionName()
        {
            return _collectionName;
        }
    }
}
