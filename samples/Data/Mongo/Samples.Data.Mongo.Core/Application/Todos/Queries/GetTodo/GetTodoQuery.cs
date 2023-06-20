using MediatR;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<TodoVm>
    {
        public string Id { get; set; }
    }
}
