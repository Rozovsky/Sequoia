using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Options;
using Sequoia.Data.Mongo.Persistence;

[assembly: SequoiaMember()]
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

        /*public static IServiceCollection AddPostgresql<TContextInterface, TContext>(this IServiceCollection services, string connectionString)
    where TContext : DbContext, TContextInterface
    where TContextInterface : class
        {
            // add pgsql db
            services.AddDbContext<TContext>(options =>
                options.UseNpgsql(connectionString,
                    b => b.MigrationsAssembly(typeof(TContext).Assembly.FullName)));

            services.AddScoped<TContextInterface>(provider => provider.GetService<TContext>());

            return services;
        }*/
    }
}
