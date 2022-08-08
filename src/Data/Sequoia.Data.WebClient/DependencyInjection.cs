using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Data.WebClient.Interfaces;
using Sequoia.Data.WebClient.Options;
using Sequoia.Data.WebClient.Repositories;
using Sequoia.Data.WebClient.Services;

namespace Sequoia.Data.WebClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebClient(this IServiceCollection services, IConfiguration configuration)
        {
            // register options
            services.Configure<WebResourcesOptions>(configuration.GetSection("WebResources"));

            // add context accessor
            services.AddHttpContextAccessor();

            // register IHttpClientFactory
            services.AddHttpClient();
            services.AddHttpClient("no-ssl-validation")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback =
                            (httpRequestMessage, cert, certChain, policyErrors) => true
                    };
                });

            // register web client services
            services.AddTransient<IWebClient, WebClientEngine>();

            // register oauth repository
            services.AddSingleton<IOAuthRepository, OAuthRepository>();

            return services;
        }
    }
}
