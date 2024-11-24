using Sequoia.Constants;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Client.Exceptions;

public class ResourceNotFoundException : KernelException
{
    public ResourceNotFoundException() : base(
        (int)HttpStatusCode.NotFound,
        "Sequoia.Client.Http.Exception: resource not found",
        DefaultExceptionType.NotFoundError)
    {
    }

    public ResourceNotFoundException(string name) : base(
        (int)HttpStatusCode.NotFound,
        $"Sequoia.Client.Http.Exception: resource {name} not found",
        DefaultExceptionType.NotFoundError)
    {
    }
}