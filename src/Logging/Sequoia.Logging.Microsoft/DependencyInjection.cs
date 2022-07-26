using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Logging.Microsoft.Behaviours;

namespace Sequoia.Logging.Microsoft
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMicrosoftLogging(this IServiceCollection services, IConfiguration configuration)
        {
            // register cross cutting concerns
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));

            return services;
        }
    }
}
