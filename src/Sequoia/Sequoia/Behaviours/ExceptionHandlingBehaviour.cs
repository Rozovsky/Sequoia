using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sequoia.Exceptions;

namespace Sequoia.Behaviours
{
    public class ExceptionHandlingBehaviour<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : KernelException
        where TResponse : class
        where TRequest : IRequest<TResponse>
    {
        private readonly HttpContext _httpContext;
        private readonly ILogger<ExceptionHandlingBehaviour<TRequest, TResponse, TException>> _logger;

        public ExceptionHandlingBehaviour(IHttpContextAccessor httpContextAccessor, ILogger<ExceptionHandlingBehaviour<TRequest, TResponse, TException>> logger)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _logger = logger;
        }

        public async Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var responseJson = JsonConvert.SerializeObject(new
            {
                Code = exception.Code,
                Message = exception.Message,
                Type = exception.Type,
                Data = exception.Data
            });

            var requestJson = JsonConvert.SerializeObject(request);

            //Console.WriteLine(request);

            //_httpContext.Response.ContentType = "application/json";
            //_httpContext.Response.StatusCode = exception.Code;

            //await _httpContext.Response.WriteAsync(
            //    JsonConvert.SerializeObject(exception), cancellationToken: cancellationToken);

            _logger.LogError("{@path}: {@request} / {@response}", 
                _httpContext.Request.Path, requestJson, responseJson);

            state.SetHandled(default);
        }
    }
}
