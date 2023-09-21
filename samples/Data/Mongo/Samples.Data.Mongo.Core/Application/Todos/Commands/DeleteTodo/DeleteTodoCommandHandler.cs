using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.DeleteTodo
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
