using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Domain;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken);
        Task<Todo> GetTodo(string id, CancellationToken cancellationToken);
    }
}
