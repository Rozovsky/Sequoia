using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Queries.GetTodo;

public class GetTodoQueryValidator : AbstractValidator<GetTodoQuery>
{
    public GetTodoQueryValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");
    }
}