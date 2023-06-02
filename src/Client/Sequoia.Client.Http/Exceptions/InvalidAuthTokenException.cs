using Sequoia.Constants;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Client.Http.Exceptions
{
    public class InvalidAuthTokenException : KernelException
    {
        public InvalidAuthTokenException() : base(
            (int)HttpStatusCode.NotAcceptable,
            "Sequoia.Client.Http.Exception: invalid token - token must be Basic or Bearer",
            DefaultExceptionType.WebClientError)
        {
        }
    }
}
