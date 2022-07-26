using FluentValidation.Results;
using Sequoia.Constants;
using System.Net;

namespace Sequoia.Exceptions
{
    public class KernelValidationException : KernelException
    {
        public KernelValidationException(IEnumerable<ValidationFailure> failures) 
            : base(
                  (int)HttpStatusCode.UnprocessableEntity, 
                  "One or more validation failures have occurred.",
                  DefaultExceptionType.ValidationError,
                  null)
        {
            var errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

            base.Details = new { ValidationErrors = errors };
        }
    }
}
