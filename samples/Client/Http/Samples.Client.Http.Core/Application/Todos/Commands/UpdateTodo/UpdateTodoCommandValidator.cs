using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(v => v.Dto.Title)
            .NotEmpty()
            .WithMessage("Title is required");
    }
}