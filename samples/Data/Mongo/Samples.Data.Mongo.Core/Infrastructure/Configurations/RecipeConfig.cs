namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class RecipeConfig
    {
        private const string _collectionName = "recipes";

        public static string GetCollectionName()
        {
            return _collectionName;
        }
    }
}
