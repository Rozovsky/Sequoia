using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Common.Services;
using Samples.Data.WebClient.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Attributes;

namespace Samples.Data.WebClient.Core
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

            // add application services
            services.AddTransient<ICoffeeMachineService, CoffeeMachineService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IStoreService, StoreService>();

            // add application repositories
            services.AddTransient<ICoffeeMachineRepository, CoffeeMachineRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();

            return services;
        }
    }
}
