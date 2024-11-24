using MediatR;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Queries.GetTodo;

public class GetTodoQuery : IRequest<TodoVm>
{
    public long Id { get; set; }
}