using MediatR;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<List<TodoVm>>
    {
    }
}
