using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be greater than 0");
        }
    }
}
