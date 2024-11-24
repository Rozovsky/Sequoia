using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sequoia.Attributes;
using Sequoia.Authentication.Bearer.Swagger.Options;

namespace Sequoia.Authentication.Bearer.Swagger;

[SequoiaMember]
public static class DependencyInjection
{
    /// <summary>
    /// Add JWT Bearer authentication
    /// </summary>
    public static IServiceCollection AddAuthBearerSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection("AuthBearer").Get<AuthSwaggerOptions>();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = authOptions.Swagger.Title,
                Version = authOptions.Swagger.Version,
            });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Enter a valid JWT",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}