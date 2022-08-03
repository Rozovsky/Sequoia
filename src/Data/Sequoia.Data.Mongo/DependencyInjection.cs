using Microsoft.Extensions.DependencyInjection;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Options;
using Sequoia.Data.Mongo.Persistence;

namespace Sequoia.Data.Mongo
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString, string database)
        {
            services.AddSingleton(_ => new MongoConnectionOptions(connectionString, database));
            services.AddScoped<IMongoContext, MongoContext>();

            return services;
        }
    }
}
