using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Application.Common.Services;
using Samples.Authentication.Basic.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Attributes;

namespace Samples.Authentication.Basic.Core
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
            services.AddTransient<ILocationService, LocationService>();

            // add application repositories
            services.AddTransient<ILocationRepository, LocationRepository>();

            return services;
        }
    }
}
