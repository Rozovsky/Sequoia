using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;

namespace Samples.Common.Application;

[SequoiaMember]
public static class DependencyInjection
{
    /// <summary>
    /// Add application services
    /// </summary>
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}