using FluentValidation;
using MediatR;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                    .WithMessage("Id is required")
                .NotNull()
                    .WithMessage("Id is required");
        }
    }
}
