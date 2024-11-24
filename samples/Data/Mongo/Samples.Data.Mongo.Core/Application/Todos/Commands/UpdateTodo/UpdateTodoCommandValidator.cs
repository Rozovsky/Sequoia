using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Dto.Title)
            .NotEmpty()
            .WithMessage("Title is required");
    }
}