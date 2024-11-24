using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(v => v.Dto.Title)
            .NotEmpty()
            .WithMessage("Title is required");
    }
}