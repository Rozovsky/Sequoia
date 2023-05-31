using MediatR;

namespace Samples.Client.Http.Core.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest
    {
        public long Id { get; set; }
    }
}
