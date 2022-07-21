using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Sequoia.Complex.Core.Application.Common.Interfaces;
using Samples.Sequoia.Complex.Core.Application.Common.Services;
using Sequoia;
using System.Reflection;

namespace Samples.Sequoia.Complex.Core
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

            // add kernel web client
            //services.AddWebClient(configuration);

            // add mongo db
            //services.AddMongoDb(configuration.GetConnectionString("MongoConnection"), "orders");

            // add application services
            services.AddTransient<ICoffeeService, CoffeeService>();

            // add application repositories
            //services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
