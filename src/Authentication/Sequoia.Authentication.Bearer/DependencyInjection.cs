using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sequoia.Attributes;
using Sequoia.Authentication.Bearer.Options;
using Sequoia.Authentication.Bearer.Services;
using Sequoia.Authentication.Interfaces;
using System.Text;

namespace Sequoia.Authentication.Bearer;

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
}