using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(ITodoService todoService) : IRequestHandler<DeleteTodoCommand>
{
    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await todoService.DeleteTodo(request.Id, cancellationToken);
    }
}