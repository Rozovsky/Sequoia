﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Client.Http.Options;

namespace Sequoia.Client.Http
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSequoiaHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            // register options
            services.Configure<HttpClientOptions>(configuration.GetSection("HttpClientOptions"));

            // add context accessor
            services.AddHttpContextAccessor();

            // register IHttpClientFactory
            services.AddHttpClient("default");

            // register web client services
            //services.AddTransient<IWebClient, WebClientEngine>();

            // register oauth repository
            //services.AddSingleton<IOAuthRepository, OAuthRepository>();

            return services;
        }
    }
}
