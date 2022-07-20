using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Kernel;
using System.Reflection;

namespace Sequoia
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSequoia(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            // add required modules
            services.AddKernel(executingAssembly, configuration);

            return services;
        }
    }
}
