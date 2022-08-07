using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Data.Abstractions;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Options;
using Sequoia.Data.Mongo.Persistence;

namespace Sequoia.Data.Mongo
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        //public static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString, string database)
        //{
        //    services.AddSingleton(_ => new MongoConnectionOptions(connectionString, database));
        //    services.AddScoped<IMongoContext, MongoContext>();

        //    services.AddAutoMapper(typeof(PagedWrapper<>));

        //    return services;
        //}

        public static IServiceCollection AddMongoDb<TContextInterface, TContext>(
            this IServiceCollection services, string connectionString, string database)
            where TContext : TContextInterface
            where TContextInterface : class
        {
            services.AddSingleton(_ => new MongoConnectionOptions(connectionString, database));
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<TContextInterface>(provider => provider.GetService<TContext>());

            services.AddAutoMapper(typeof(PagedWrapper<>));

            return services;
        }
    }
}
