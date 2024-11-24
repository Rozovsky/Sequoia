using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodo;

public class GetTodoQueryValidator : AbstractValidator<GetTodoQuery>
{
    public GetTodoQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}