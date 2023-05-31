using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Domain.Entities;
using Sequoia.Client.Http;

namespace Samples.Client.Http.Core.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IClient _client;

        public TodoRepository(IClient client)
        {
            _client = client;
        }

        public async Task<Todo> GetTodo(long id, CancellationToken cancellationToken)
        {
            var result = await _client
                .Path("https://jsonplaceholder.typicode.com/todos")
                .Get<Todo>($"/{id}", cancellationToken);

            return result;
        }

        public async Task<List<Todo>> GetTodos(CancellationToken cancellationToken)
        {
            var result = await _client
                .Path("jsonplaceholder/todo")
                .Get<List<Todo>>(cancellationToken);

            return result;
        }

        public async Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _client
               .Path("jsonplaceholder/todo")
               .Body(dto)
               .Post<Todo>(cancellationToken);

            return result;
        }

        public async Task<Todo> UpdateTodo(long id, TodoToUpdateDto dto, CancellationToken cancellationToken)
        {
            var result = await _client
               .Path("jsonplaceholder/todo")
               .Body(dto)
               .Put<Todo>($"/{id}", cancellationToken);

            return result;
        }

        public async Task DeleteTodo(long id, CancellationToken cancellationToken)
        {
            await _client
               .Path("jsonplaceholder/todo")
               .Delete($"/{id}", cancellationToken);
        }

        public async Task<Todo> PatchCompleted(long id, TodoCompletedToPatchDto dto, CancellationToken cancellationToken)
        {
            var result = await _client
             .Path("jsonplaceholder/todo")
             .Body(dto)
             .Patch<Todo>($"/{id}", cancellationToken);

            return result;
        }
    }
}
