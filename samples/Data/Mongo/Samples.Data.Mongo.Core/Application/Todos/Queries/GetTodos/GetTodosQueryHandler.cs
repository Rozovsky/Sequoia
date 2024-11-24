using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<GetTodosQuery, List<TodoVm>>
{
    public async Task<List<TodoVm>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var result = await todoService.GetTodos(cancellationToken);

        return mapper.Map<List<TodoVm>>(result);
    }
}