using Sequoia.Authentication.Bearer.Options;

namespace Sequoia.Authentication.Bearer.Swagger.Options;

public class AuthSwaggerOptions : AuthBearerOptions
{
    public AuthSwaggerSection Swagger { get; set; }
}