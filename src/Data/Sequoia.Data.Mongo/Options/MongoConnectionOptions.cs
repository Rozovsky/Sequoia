namespace Sequoia.Data.Mongo.Options
{
    public class MongoConnectionOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }

        public MongoConnectionOptions(string connectionString, string database)
        {
            ConnectionString = connectionString;
            Database = database;
        }
    }
}
