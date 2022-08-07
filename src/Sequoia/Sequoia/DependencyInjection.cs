using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Behaviours;
using System.Reflection;

namespace Sequoia
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSequoia(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            //var sequoiaAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(a => a.GetTypes().Where(t => t.IsDefined(typeof(SequoiaMemberAttribute))));

            var sequoiaAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(c => c.IsDefined(typeof(SequoiaMemberAttribute)))
                .ToList();

            // register common components
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly, Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            // register cross cutting concerns
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
