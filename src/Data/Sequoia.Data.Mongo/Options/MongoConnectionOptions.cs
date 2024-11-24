namespace Sequoia.Data.Mongo.Options;

public class MongoConnectionOptions(string connectionString, string database)
{
    public string ConnectionString { get; set; } = connectionString;
    public string Database { get; set; } = database;
}