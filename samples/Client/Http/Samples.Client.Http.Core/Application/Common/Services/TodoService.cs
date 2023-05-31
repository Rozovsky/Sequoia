using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Domain.Entities;

namespace Samples.Client.Http.Core.Application.Common.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> GetTodo(long id, CancellationToken cancellationToken)
        {
            var result = await _todoRepository.GetTodo(id, cancellationToken);

            return result;
        }
    }
}
