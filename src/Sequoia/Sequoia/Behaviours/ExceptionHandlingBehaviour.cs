using MediatR;
using MediatR.Pipeline;
using Sequoia.Exceptions;

namespace Sequoia.Behaviours
{
    public class ExceptionHandlingBehaviour<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TException : KernelException
    where TResponse : class
    where TRequest : IRequest<TResponse>
    {
        public async Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var response = new Exception
            {
            };

            state.SetHandled(response as TResponse);
        }
    }

    //public class ExceptionHandler<TRequest, TResponse, TException>
    //: IRequestExceptionHandler<TRequest, TResponse, TException> 
    //    where TException : Exception 
    //    where TRequest : IRequest<TResponse>
    //{
    //    Variables.
    //    private readonly IDomainNotificationHandler _notifications;


    //    public ExceptionHandler(IDomainNotificationHandler notifications)
    //    {
    //        _notifications = notifications;
    //    }

    //    public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
    //        CancellationToken cancellationToken)
    //    {
    //        var exceptionType = exception.GetType();

    //        if (!TextHelper.IsNullOrEmptyOrWhitespace(exception.Message))
    //            _notifications.Add(exceptionType.Name, exception.Message);

    //        state.SetHandled(default);
    //    }
    //}
}
