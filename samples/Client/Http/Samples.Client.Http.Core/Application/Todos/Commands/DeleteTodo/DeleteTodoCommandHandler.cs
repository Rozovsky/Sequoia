using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;

namespace Samples.Client.Http.Core.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly ITodoService _todoService;

        public DeleteTodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _todoService.DeleteTodo(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
