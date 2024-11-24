using MediatR;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommand : IRequest
{
    public string Id { get; set; }
}