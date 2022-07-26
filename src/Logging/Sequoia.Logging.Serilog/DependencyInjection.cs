using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Sequoia.Logging.Serilog
{
    /*public static class DependencyInjection
    {
        public static IHostBuilder AddSerilogLogging(this IHostBuilder builder, string indexFormat = null)
        {
            builder.UseSerilog((context, configuration)
                => ConfigurateSerilog(context, configuration, builder, indexFormat));

            return builder;
        }

        private static IHostBuilder ConfigurateSerilog(HostBuilderContext context, LoggerConfiguration configuration, IHostBuilder builder, string indexFormat)
        {
            var loggingOptions = context.Configuration.GetSection("LoggingOptions").Get<LoggingOptions>();

            configuration = configuration.Enrich.FromLogContext();

            // set log level
            switch (loggingOptions.LogLevel.Default)
            {
                case Enums.LogLevel.Verbose:
                    configuration = configuration
                        .MinimumLevel.Verbose()
                        .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                        .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                    break;

                case Enums.LogLevel.Debug:
                    configuration = configuration
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                        .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                    break;

                case Enums.LogLevel.Information:
                    configuration = configuration
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                        .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                    break;

                case Enums.LogLevel.Warning:
                    configuration = configuration
                        .MinimumLevel.Warning()
                        .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                        .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                    break;

                case Enums.LogLevel.Error:
                    configuration = configuration
                        .MinimumLevel.Error()
                        .MinimumLevel.Override("Microsoft", (LogEventLevel)loggingOptions.LogLevel.Microsoft)
                        .MinimumLevel.Override("System", (LogEventLevel)loggingOptions.LogLevel.System);
                    break;

                case Enums.LogLevel.Fatal:
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
                configuration = configuration.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);

            if (loggingOptions.WriteToConsole)
                configuration = configuration.WriteTo.Console();

            if (loggingOptions.WriteToElasticsearch)
                configuration = configuration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri($"{loggingOptions.Elasticsearch.Host}:{loggingOptions.Elasticsearch.Port}"))
                    {
                        IndexFormat = indexFormat ?? 
                            $"{context.HostingEnvironment.ApplicationName}-" +
                            $"{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}" +
                            $"-logs-{DateTime.UtcNow:yyyy}",
                        AutoRegisterTemplate = loggingOptions.Elasticsearch.AutoRegisterTemplate
                    });

            return builder;
        }
    }*/
}
