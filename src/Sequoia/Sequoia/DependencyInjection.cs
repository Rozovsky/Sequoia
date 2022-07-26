using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Behaviours;
using System.Reflection;

namespace Sequoia
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSequoia(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            // register common components
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly, Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            // register cross cutting concerns
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionHandlingBehaviour<,,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditBehaviour<,>));


            return services;
        }
    }
}
