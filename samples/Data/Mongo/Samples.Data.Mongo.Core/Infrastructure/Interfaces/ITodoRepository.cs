using Samples.Data.Mongo.Core.Domain;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> CreateTodo(Todo obj, CancellationToken cancellationToken);
        Task<Todo> GetTodo(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Todo>> GetAllTodos(CancellationToken cancellationToken);
        Task<PagedWrapper<Todo>> GetTodoPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
