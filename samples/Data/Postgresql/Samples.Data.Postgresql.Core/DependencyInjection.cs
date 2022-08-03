using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Application.Common.Services;
using Samples.Data.Postgresql.Core.Infrastructure;
using Sequoia;
using Sequoia.Data.Postgresql;
using System.Reflection;

namespace Samples.Data.Postgresql.Core
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

            // add postgres db
            services.AddPostgresql<IApplicationDbContext, ApplicationDbContext>(
                configuration.GetConnectionString("DefaultConnection"));

            // add application services
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<ICoffeeMachineService, CoffeeMachineService>();

            // add application repositories
            //services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
