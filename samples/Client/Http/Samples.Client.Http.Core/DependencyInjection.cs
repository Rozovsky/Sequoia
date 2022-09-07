using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia;
using Sequoia.Attributes;
using Sequoia.Client.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Client.Http.Core
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application services
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // register common components
            services.AddSequoia();
            services.AddSequoiaHttpClient(configuration);

            // add application services
            //services.AddTransient<IStoreService, StoreService>();

            // add application repositories
            //services.AddTransient<IStoreRepository, StoreRepository>();

            return services;
        }
    }
}
