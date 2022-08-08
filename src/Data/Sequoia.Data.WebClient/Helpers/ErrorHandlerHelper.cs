using Newtonsoft.Json;
using Sequoia.Constants;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Exceptions;
using Sequoia.Exceptions;
using System.Net;

namespace Sequoia.Data.WebClient.Helpers
{
    public static class ErrorHandlerHelper
    {
        public static object HandleError(HttpResponseMessage responseMessage, string responseData, ErrorHandlingMode handlingMode)
        {
            return handlingMode switch
            {
                ErrorHandlingMode.Ignore => null,
                ErrorHandlingMode.Manual => throw new WebClientException((int)responseMessage.StatusCode, string.IsNullOrEmpty(responseData) ? string.Empty : responseData),
                ErrorHandlingMode.Auto => GetAutoException(responseMessage.StatusCode, responseData),
                ErrorHandlingMode.Debug => throw new WebClientException((int)responseMessage.StatusCode, $"{JsonConvert.SerializeObject(responseMessage)}"),

                _ => throw new WebClientException((int)responseMessage.StatusCode, responseData),
            };
        }

        private static object GetAutoException(HttpStatusCode code, string message)
        {
            switch (code)
            {
                case HttpStatusCode.NotFound:
                    var exceptionNotFound = JsonConvert.DeserializeObject<NotFoundException>(message);
                    throw (exceptionNotFound.Type == DefaultExceptionType.NotFoundError)
                        ? exceptionNotFound
                        : new WebClientException((int)code, message);

                case HttpStatusCode.UnprocessableEntity:
                    var exceptionUnprocessableEntity = JsonConvert.DeserializeObject<KernelValidationException>(message);
                    throw (exceptionUnprocessableEntity.Type == DefaultExceptionType.ValidationError)
                        ? exceptionUnprocessableEntity
                        : new WebClientException((int)code, message);

                default:
                    throw new WebClientException((int)code, message);
            }
        }
    }
}
