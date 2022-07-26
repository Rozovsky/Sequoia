using Sequoia.Constants;
using System.Net;

namespace Sequoia.Exceptions
{
    public class MethodNotAllowedException : KernelException
    {
        public MethodNotAllowedException()
            : base((int)HttpStatusCode.MethodNotAllowed,
                  "Kernel exception: Method not allowed",
                  DefaultExceptionType.NotAllowedError)
        {
        }

        public MethodNotAllowedException(string message)
            : base((int)HttpStatusCode.MethodNotAllowed,
                  message,
                  DefaultExceptionType.NotAllowedError)
        {
        }

        public MethodNotAllowedException(string url, string method)
            : base((int)HttpStatusCode.MethodNotAllowed,
                  $"Method [{method}]: {url} is not allowed",
                  DefaultExceptionType.NotAllowedError)
        {
        }
    }
}
