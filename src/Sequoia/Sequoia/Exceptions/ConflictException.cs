using Sequoia.Constants;
using System.Net;

namespace Sequoia.Exceptions;

public class ConflictException : KernelException
{
    public ConflictException()
        : base((int)HttpStatusCode.Conflict,
            "Kernel exception: Conflict",
            DefaultExceptionType.ConflictError)
    {
    }

    public ConflictException(string message)
        : base((int)HttpStatusCode.Conflict,
            message,
            DefaultExceptionType.ConflictError)
    {
    }

    public ConflictException(string name, object key, object key2)
        : base((int)HttpStatusCode.Conflict,
            $"Kernel Conflict exception: '{name}' with id '{key}' conflicts with id '{key2}'",
            DefaultExceptionType.ConflictError)
    {
    }
}