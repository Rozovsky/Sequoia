using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.Services;
using Samples.Data.Mongo.Core.Infrastructure;
using Samples.Data.Mongo.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Data.Mongo;
using System.Reflection;

namespace Samples.Data.Mongo.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application services
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // register common components
            services.AddSequoia(Assembly.GetExecutingAssembly(), configuration);

            // add mongo db
            services.AddMongoDb(configuration.GetConnectionString("MongoConnection"), "coffee-store");
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(); // TODO: move to AddMongoDb

            // add application services
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<ICoffeeMachineService, CoffeeMachineService>();

            // add application repositories
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<ICoffeeMachineRepository, CoffeeMachineRepository>();

            return services;
        }
    }
}
