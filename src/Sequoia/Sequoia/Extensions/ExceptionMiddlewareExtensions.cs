using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sequoia.Interfaces;

namespace Sequoia.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Write IKernelExceptions to response
        /// </summary>
        public static void UseSequoiaExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var kernelException = contextFeature.Error as IKernelException;

                        context.Response.StatusCode = kernelException.Code;
                        context.Response.ContentType = "application/json";

                        var json = JsonConvert.SerializeObject(kernelException);

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
