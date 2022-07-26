using Sequoia.Constants;
using System.Net;

namespace Sequoia.Exceptions
{
    public class NotFoundException : KernelException
    {
        public NotFoundException()
            : base((int)HttpStatusCode.NotFound,
                  "Kernel exception: Not found",
                  DefaultExceptionType.NotFoundError)
        {
        }

        public NotFoundException(string message)
            : base((int)HttpStatusCode.NotFound,
                  message,
                  DefaultExceptionType.NotFoundError)
        {
        }

        public NotFoundException(string name, object key)
            : base((int)HttpStatusCode.NotFound,
                  $"Kernel NotFound exception: '{name}' with id '{key}' was not found",
                  DefaultExceptionType.NotFoundError)
        {
        }
    }
}
