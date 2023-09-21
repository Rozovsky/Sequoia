using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Domain;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken);
        Task<Todo> UpdateTodo(string id, TodoToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteTodo(string id, CancellationToken cancellationToken);
        Task<Todo> GetTodo(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Todo>> GetTodos(CancellationToken cancellationToken);
        Task<Paged<Todo>> GetTodosPaged(TodoToPagedDto dto, CancellationToken cancellationToken);
    }
}
