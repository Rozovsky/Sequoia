using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;

namespace Samples.Client.Http.Core.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(ITodoService todoService) : IRequestHandler<DeleteTodoCommand>
{
    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await todoService.DeleteTodo(request.Id, cancellationToken);
    }
}