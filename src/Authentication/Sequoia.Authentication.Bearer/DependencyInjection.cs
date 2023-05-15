using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sequoia.Attributes;
using Sequoia.Authentication.Bearer.Options;
using Sequoia.Authentication.Bearer.Services;
using Sequoia.Authentication.Interfaces;
using System.Text;

namespace Sequoia.Authentication.Bearer
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add JWT Bearer authentication
        /// </summary>
        public static IServiceCollection AddAuthBearer(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("AuthBearer").Get<AuthBearerOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidAudience = authOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SigningKey)),
                    };
                });

            // add default current user services
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        /// <summary>
        /// Add JWT Bearer authentication
        /// </summary>
        public static IServiceCollection AddAuthBearerSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("AuthBearer").Get<AuthBearerOptions>();

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
}
