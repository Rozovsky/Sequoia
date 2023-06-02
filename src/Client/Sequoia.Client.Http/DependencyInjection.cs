using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Client.Http.Configuration;
using Sequoia.Client.Http.Options;

namespace Sequoia.Client.Http
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientHttp(this IServiceCollection services, IConfiguration configuration)
        {
            // register options
            services.Configure<HttpClientOptions>(configuration.GetSection("HttpClient"));

            // add context accessor
            services.AddHttpContextAccessor();

            // register IHttpClientFactory
            services.AddHttpClient("default");

            // register web client services
            services.AddTransient<ClientConfiguration>();
            services.AddTransient<IClient, Client>();

            return services;
        }
    }
}
