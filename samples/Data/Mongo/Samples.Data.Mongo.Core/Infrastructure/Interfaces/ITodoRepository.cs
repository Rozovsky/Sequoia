using Samples.Data.Mongo.Core.Domain;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> CreateTodo(Todo obj, CancellationToken cancellationToken);
        Task<Todo> GetTodo(string id, CancellationToken cancellationToken);
    }
}
