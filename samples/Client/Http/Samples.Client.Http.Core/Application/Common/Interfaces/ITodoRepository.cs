using Samples.Client.Http.Core.Domain.Entities;

namespace Samples.Client.Http.Core.Application.Common.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetTodo(long id, CancellationToken cancellationToken);
    }
}
