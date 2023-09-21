using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodos
{
    public class GetTodosQueryValidator : AbstractValidator<GetTodosQuery>
    {
        public GetTodosQueryValidator()
        {
        }
    }
}
