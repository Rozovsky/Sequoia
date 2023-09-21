using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.Services;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Samples.Data.Mongo.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Attributes;
using Sequoia.Data.Mongo;

namespace Samples.Data.Mongo.Core
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application services
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // register common components
            services.AddSequoia();

            // add mongo db
            services.AddMongoDb(configuration.GetConnectionString("MongoConnection"), "samples_data_mongo");

            // add application services
            services.AddTransient<ITodoService, TodoService>();

            // add application repositories (local implementation)
            services.AddTransient<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
