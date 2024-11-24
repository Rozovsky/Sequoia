using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Domain.Entities;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Common.Services;

public class TodoService(ITodoRepository todoRepository) : ITodoService
{
    public async Task<Todo> CreateTodo(TodoToCreateDto dto, CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
            Translations = dto.Translations,
            UserId = dto.UserId
        };

        return await todoRepository.Create(todo, cancellationToken);
    }

    public async Task<Todo> UpdateTodo(string id, TodoToUpdateDto dto, CancellationToken cancellationToken)
    {
        var todo = await GetTodo(id, cancellationToken);

        todo.UserId = dto.UserId;
        todo.Description = dto.Description;
        todo.Title = dto.Title;
        todo.Completed = dto.Completed;
        todo.Translations = dto.Translations;

        todo = await todoRepository.Update(c => c.Id == id, todo, cancellationToken);

        return todo;
    }

    public async Task DeleteTodo(string id, CancellationToken cancellationToken)
    {
        var todo = await GetTodo(id, cancellationToken);

        await todoRepository.Delete(c => c.Id == id, cancellationToken);
    }

    public async Task<Todo> GetTodo(string id, CancellationToken cancellationToken)
    {
        return await todoRepository.Get(c => c.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Todo>> GetTodos(CancellationToken cancellationToken)
    {
        return await todoRepository.GetAll(cancellationToken);
    }

    public async Task<Paged<Todo>> GetTodosPaged(TodoToPagedDto dto, CancellationToken cancellationToken)
    {
        var sort = Builders<Todo>.Sort.Ascending(c => c.Id);

        if (dto.Sort != null)
        {
            sort = (dto.Sort.Desc)
                ? Builders<Todo>.Sort.Descending(dto.Sort.Field)
                : Builders<Todo>.Sort.Ascending(dto.Sort.Field);
        }

        var filterTitle = (dto.Filter?.Title == null)
            ? Builders<Todo>.Filter.Empty
            : Builders<Todo>.Filter.Where(c => c.Title.ToLower().Contains(dto.Filter.Title.ToLower()));

        var filterUserId = (dto.Filter?.UserId == null)
            ? Builders<Todo>.Filter.Empty
            : Builders<Todo>.Filter.Eq(c => c.UserId, dto.Filter.UserId);

        var filterCompleted = (dto.Filter?.Completed == null)
            ? Builders<Todo>.Filter.Empty
            : Builders<Todo>.Filter.Eq(c => c.Completed, dto.Filter.Completed);

        var filters = Builders<Todo>.Filter.And(filterTitle, filterUserId, filterCompleted);

        return await todoRepository.GetPaged(filters, sort, dto.Page, dto.PageSize, cancellationToken);
    }
}