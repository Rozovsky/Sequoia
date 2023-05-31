using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Commands.PatchCompleted
{
    public class PatchCompletedCommandValidator : AbstractValidator<PatchCompletedCommand>
    {
        public PatchCompletedCommandValidator()
        {
        }
    }
}
