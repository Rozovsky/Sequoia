using FluentValidation;

namespace Samples.Client.Http.Core.Application.Todos.Queries.GetTodos
{
    public class GetTodosQueryValidator : AbstractValidator<GetTodosQuery>
    {
        public GetTodosQueryValidator()
        {
        }
    }
}
