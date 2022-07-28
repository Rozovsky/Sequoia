using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sequoia.Logging.Microsoft.Behaviours;

namespace Sequoia.Logging.Microsoft
{
    public static class DependencyInjection
    {
        public static ILoggingBuilder AddMicrosoftLoggingDef(this ILoggingBuilder builder, IConfiguration configuration)
        {
            //builder.ClearProviders();
            //builder.AddConsole().SetMinimumLevel(LogLevel.Trace);

            builder.SetMinimumLevel(LogLevel.Debug);

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            // register cross cutting concerns
            //services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));

            //builder.SetMinimumLevel(LogLevel.Debug);

            //builder.log..AddProvider(loggerprovider);

            //register cross cutting concerns
            //builder.services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));

            //builder.UseSerilog((context, configuration)
            //    => ConfigurateSerilog(context, configuration, builder, indexFormat));

            return builder;
        }

        public static IServiceCollection AddMicrosoftLogging(this IServiceCollection services, IConfiguration configuration)
        {
            // register cross cutting concerns
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));

            return services;
        }
    }
}
