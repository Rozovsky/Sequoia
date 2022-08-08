using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Authentication.Interfaces;
using Sequoia.Authentication.Services;

namespace Sequoia.Authentication
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add default current user service
        /// </summary>
        public static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            // add default current user services
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
