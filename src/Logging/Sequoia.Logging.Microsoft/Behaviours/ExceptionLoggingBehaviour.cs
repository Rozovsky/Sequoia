using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sequoia.Exceptions;
using Sequoia.Interfaces;

namespace Sequoia.Logging.Microsoft.Behaviours;

public class ExceptionLoggingBehaviour<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TException : KernelException
    where TResponse : class
    where TRequest : IRequest<TResponse>
{
    private readonly HttpContext _httpContext;
    private readonly ILogger<ExceptionLoggingBehaviour<TRequest, TResponse, TException>> _logger;

    public ExceptionLoggingBehaviour(
        IHttpContextAccessor httpContextAccessor, 
        ILogger<ExceptionLoggingBehaviour<TRequest, TResponse, TException>> logger)
    {
        _httpContext = httpContextAccessor.HttpContext;
        _logger = logger;
    }

    public async Task Handle(TRequest request,
        TException exception,
        RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        var kernelException = exception as IKernelException;
        var requestJson = JsonConvert.SerializeObject(request);
        var responseJson = JsonConvert.SerializeObject(kernelException);

        _logger.LogError("Sequoia.Logging.Microsoft: {@method} {@path} {@request} / {@response}",
            _httpContext.Request.Method, _httpContext.Request.Path, requestJson, responseJson);

        state.SetHandled(default);
    }
}