using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Options;
using Sequoia.Data.Mongo.Persistence;

namespace Sequoia.Data.Mongo;

[SequoiaMember]
public static class DependencyInjection
{
    public static IServiceCollection AddMongoDb<TContextInterface, TContext>(
        this IServiceCollection services, string connectionString, string database)
        where TContext : TContextInterface
        where TContextInterface : class
    {
        services.AddSingleton(_ => new MongoConnectionOptions(connectionString, database));
        services.AddScoped<IMongoContext, MongoContext>();
        services.AddScoped(typeof(TContextInterface), typeof(TContext));

        // enable entities configs
        var entityConfigs = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(IMongoEntityConfig).IsAssignableFrom(p) && p.IsClass);

        foreach (var entityConfigType in entityConfigs)
        {
            var instance = Activator.CreateInstance(entityConfigType);
            var entityConfigInstance = instance as IMongoEntityConfig;

            entityConfigInstance.Configure();
        }

        services.AddAutoMapper(typeof(Paged<>));

        return services;
    }

    public static IServiceCollection AddMongoDb(
        this IServiceCollection services, string connectionString, string database)
    {
        services.AddSingleton(_ => new MongoConnectionOptions(connectionString, database));
        services.AddScoped<IMongoContext, MongoContext>();

        services.AddAutoMapper(typeof(Paged<>));

        return services;
    }
}