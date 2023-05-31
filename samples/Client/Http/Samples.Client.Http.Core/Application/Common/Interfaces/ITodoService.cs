using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Domain.Entities;

namespace Samples.Client.Http.Core.Application.Common.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> GetTodo(long id, CancellationToken cancellationToken);
        Task<List<Todo>> GetTodos(CancellationToken cancellationToken);
        Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken);
        Task<Todo> UpdateTodo(long id, TodoToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteTodo(long id, CancellationToken cancellationToken);
        Task<Todo> PatchCompleted(long id, TodoCompletedToPatchDto dto, CancellationToken cancellationToken);
    }
}
