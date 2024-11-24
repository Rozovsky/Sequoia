using MediatR;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodos;

public class GetTodosQuery : IRequest<List<TodoVm>>
{
}