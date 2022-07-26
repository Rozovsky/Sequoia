using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sequoia.Exceptions;
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
            var requestJson = JsonConvert.SerializeObject(request);

            var responseJson = JsonConvert.SerializeObject(new
            {
                Code = exception.Code,
                Message = exception.Message,
                Type = exception.Type,
                Data = exception.Data
            });

            _logger.Error("{@path}: {@request} / {@response}",
                _httpContext.Request.Path, requestJson, responseJson);

            state.SetHandled(default);
        }
    }
}
