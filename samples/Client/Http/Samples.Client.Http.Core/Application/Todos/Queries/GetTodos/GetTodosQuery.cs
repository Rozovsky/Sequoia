using MediatR;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<List<TodoVm>>
    {
    }
}
