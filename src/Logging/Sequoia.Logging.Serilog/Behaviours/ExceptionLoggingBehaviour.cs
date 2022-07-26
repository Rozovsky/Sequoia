using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sequoia.Exceptions;
using Sequoia.Interfaces;
using Serilog;

namespace Sequoia.Logging.Serilog.Behaviours
{
    public class ExceptionLoggingBehaviour<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : KernelException
        where TResponse : class
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly HttpContext _httpContext;

        public ExceptionLoggingBehaviour(
            ILogger logger, 
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var kernelException = exception as IKernelException;
            var requestJson = JsonConvert.SerializeObject(request);
            var responseJson = JsonConvert.SerializeObject(kernelException);

            _logger.Error("Sequoia.Logging.Serilog: {@method} {@path} {@request} / {@response}",
                _httpContext.Request.Method, _httpContext.Request.Path, requestJson, responseJson);

            state.SetHandled(default);
        }
    }
}
