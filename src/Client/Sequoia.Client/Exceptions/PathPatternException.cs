using Sequoia.Constants;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Client.Exceptions
{
    public class PathPatternException : KernelException
    {
        public PathPatternException(): base(
            (int)HttpStatusCode.NotAcceptable,
            "Sequoia.Client.Http.Exception: invalid path pattern - only urls and web resources in 'Resource/Segment' format are allowed",
            DefaultExceptionType.WebClientError)
        {
        }

        public PathPatternException(string pattern) : base(
            (int)HttpStatusCode.NotAcceptable,
            $"Sequoia.Client.Http.Exception: invalid path pattern ({pattern}) - only urls and web resources in 'Resource/Segment' format are allowed",
            DefaultExceptionType.WebClientError)
        {
        }
    }
}
