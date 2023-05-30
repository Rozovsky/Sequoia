using Sequoia.Constants;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Client.Http.Exceptions
{
    public class HttpClientException : KernelException
    {
        public HttpClientException(HttpStatusCode code, string content) : base(
            (int)code, "Sequoia.Client.Http.Exception: " + content, DefaultExceptionType.WebClientError)
        {
        }
    }
}
