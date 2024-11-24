using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodo;

public class GetTodoQueryHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<GetTodoQuery, TodoVm>
{
    public async Task<TodoVm> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var result = await todoService.GetTodo(request.Id, cancellationToken);

        return mapper.Map<TodoVm>(result);
    }
}