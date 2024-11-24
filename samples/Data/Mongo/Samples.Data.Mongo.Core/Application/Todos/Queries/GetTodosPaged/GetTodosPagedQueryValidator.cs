using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodosPaged;

public class GetTodosPagedQueryValidator : AbstractValidator<GetTodosPagedQuery>
{
    public GetTodosPagedQueryValidator()
    {
        RuleFor(x => x.Dto.Page)
            .GreaterThan(0)
            .WithMessage("Page is required");

        RuleFor(x => x.Dto.PageSize)
            .GreaterThan(0)
            .WithMessage("PageSize is required");
    }
}