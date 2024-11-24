using Sequoia.Constants;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Client.Exceptions;

public class SegmentNotFoundException : KernelException
{
    public SegmentNotFoundException() : base(
        (int)HttpStatusCode.NotFound,
        "Sequoia.Client.Http.Exception: segment not found",
        DefaultExceptionType.NotFoundError)
    {
    }

    public SegmentNotFoundException(string name, string resource) : base(
        (int)HttpStatusCode.NotFound,
        $"Sequoia.Client.Http.Exception: segment {name} not found in {resource}",
        DefaultExceptionType.NotFoundError)
    {
    }
}