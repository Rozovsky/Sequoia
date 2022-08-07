using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Behaviours;
using System.Reflection;

namespace Sequoia
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        // TODO: for deleting
        public static IServiceCollection AddSequoia(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            // register common components
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly, Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            // register cross cutting concerns
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }

        public static IServiceCollection AddSequoia(this IServiceCollection services)
        {
            // get sequoia assemblies
            var sequoiaAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(c => c.GetTypes().Any(t => t.IsDefined(typeof(SequoiaMemberAttribute))))
                .ToArray();

            // register common components
            services.AddAutoMapper(sequoiaAssemblies);
            services.AddValidatorsFromAssemblies(sequoiaAssemblies);
            services.AddMediatR(sequoiaAssemblies);

            services.AddHttpContextAccessor();

            // register cross cutting concerns
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
