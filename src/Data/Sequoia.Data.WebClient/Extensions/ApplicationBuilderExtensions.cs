using Microsoft.AspNetCore.Builder;

namespace Sequoia.Data.WebClient.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOAuthRepository(this IApplicationBuilder builder)
        {
            //return builder.UseMiddleware<ExceptionHandlerMiddleware>();

            return builder;
        }
    }
}
