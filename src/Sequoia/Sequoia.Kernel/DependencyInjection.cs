using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sequoia.Kernel
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKernel(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            // register common components
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
