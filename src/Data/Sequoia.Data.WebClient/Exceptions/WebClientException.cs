using Sequoia.Exceptions;

namespace Sequoia.Data.WebClient.Exceptions
{
    public class WebClientException : KernelException
    {
        public WebClientException(int httpStatusCode, string errorMessage)
            : base(httpStatusCode, errorMessage,  "WEB_CLIENT_ERROR")
        {
        }
    }
}
