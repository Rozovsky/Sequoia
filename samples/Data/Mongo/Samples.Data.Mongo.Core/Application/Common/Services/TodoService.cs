using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Common.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                Completed = dto.Completed,
                Description = dto.Description,
                Translations = dto.Translations,
                UserId = dto.UserId
            };

            return await _todoRepository.CreateTodo(todo, cancellationToken);
        }

        public async Task<Todo> GetTodo(string id, CancellationToken cancellationToken)
        {
            return await _todoRepository.GetTodo(id, cancellationToken);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos(CancellationToken cancellationToken)
        {
            return await _todoRepository.GetAllTodos(cancellationToken);
        }

        public async Task<PagedWrapper<Todo>> GetTodoPaged(int page, int limit, CancellationToken cancellationToken)
        {
            return await _todoRepository.GetTodoPaged(page, limit, cancellationToken);
        }
    }
}
