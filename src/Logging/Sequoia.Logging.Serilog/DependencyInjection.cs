using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sequoia.Logging.Enums;
using Sequoia.Logging.Options;
using Sequoia.Logging.Serilog.Behaviours;
using Serilog;
using Serilog.Events;

namespace Sequoia.Logging.Serilog;

public static class DependencyInjection
{
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        // register cross cutting concerns
        services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));

        return services;
    }

    public static IHostBuilder AddSerilogLogging(this IHostBuilder builder, string indexFormat = null)
    {
        builder.UseSerilog((context, configuration)
            => ConfigurateSerilog(context, configuration, builder, indexFormat));

        return builder;
    }

    private static IHostBuilder ConfigurateSerilog(HostBuilderContext context, LoggerConfiguration configuration,
        IHostBuilder builder, string indexFormat)
    {
        var loggingOptions = context.Configuration.GetSection("LoggingOptions").Get<LoggingOptions>();

        configuration = configuration.Enrich.FromLogContext();

        // set log level
        switch (loggingOptions.LogLevel.Default)
        {
            case LoggingLevel.Verbose:
                configuration = configuration
                    .MinimumLevel.Verbose()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;

            case LoggingLevel.Debug:
                configuration = configuration
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;

            case LoggingLevel.Information:
                configuration = configuration
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;

            case LoggingLevel.Warning:
                configuration = configuration
                    .MinimumLevel.Warning()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;

            case LoggingLevel.Error:
                configuration = configuration
                    .MinimumLevel.Error()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;

            case LoggingLevel.Fatal:
                configuration = configuration
                    .MinimumLevel.Fatal()
                    .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                    .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                break;
        }

        // set log level overrides
        if (loggingOptions.LogMachineName)
            configuration = configuration.Enrich.WithMachineName();

        if (loggingOptions.LogEnvironment)
            configuration =
                configuration.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);

        if (loggingOptions.WriteToConsole)
            configuration = configuration.WriteTo.Console();

        // if (loggingOptions.Elasticsearch.WriteToElasticsearch)
        //     _ = configuration.WriteTo.Elasticsearch(
        //         new ElasticsearchSinkOptions(new Uri($"{loggingOptions.Elasticsearch.Host}:{loggingOptions.Elasticsearch.Port}"))
        //         {
        //             IndexFormat = indexFormat ?? 
        //                           $"{context.HostingEnvironment.ApplicationName}-" +
        //                           $"{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}" +
        //                           $"-logs-{DateTime.UtcNow:yyyy}",
        //             AutoRegisterTemplate = loggingOptions.Elasticsearch.AutoRegisterTemplate
        //         });

        return builder;
    }
}