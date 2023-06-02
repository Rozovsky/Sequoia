using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.Services;
using Samples.Client.Http.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Attributes;
using Sequoia.Client.Http;

namespace Samples.Client.Http.Core
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application services
        /// </summary>
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            // register common components
            services.AddSequoia();
            services.AddClientHttp(configuration);

            // add application services
            services.AddTransient<ITodoService, TodoService>();

            // add application repositories
            services.AddTransient<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
