using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Dto.Title)
            .NotEmpty()
            .WithMessage("Title is required");
    }
}