using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Domain.Entities;

namespace Samples.Client.Http.Core.Application.Common.Services;

public class TodoService(ITodoRepository todoRepository) : ITodoService
{
    public async Task<Todo> GetTodo(long id, CancellationToken cancellationToken)
    {
        var result = await todoRepository.GetTodo(id, cancellationToken);

        return result;
    }

    public async Task<List<Todo>> GetTodos(CancellationToken cancellationToken)
    {
        var result = await todoRepository.GetTodos(cancellationToken);

        return result;
    }

    public async Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken)
    {
        var result = await todoRepository.CreateTodo(dto, cancellationToken);

        return result;
    }

    public async Task<Todo> UpdateTodo(long id, TodoToUpdateDto dto, CancellationToken cancellationToken)
    {
        var result = await todoRepository.UpdateTodo(id, dto, cancellationToken);

        return result;
    }

    public async Task DeleteTodo(long id, CancellationToken cancellationToken)
    {
        await todoRepository.DeleteTodo(id, cancellationToken);
    }

    public async Task<Todo> PatchCompleted(long id, TodoCompletedToPatchDto dto, CancellationToken cancellationToken)
    {
        var result = await todoRepository.PatchCompleted(id, dto, cancellationToken);

        return result;
    }
}