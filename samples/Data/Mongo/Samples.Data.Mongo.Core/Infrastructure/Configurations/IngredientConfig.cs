namespace Samples.Data.Mongo.Core.Infrastructure.Configurations
{
    public class IngredientConfig
    {
        private const string _collectionName = "ingredients";

        public static string GetCollectionName()
        {
            return _collectionName;
        }
    }
}
