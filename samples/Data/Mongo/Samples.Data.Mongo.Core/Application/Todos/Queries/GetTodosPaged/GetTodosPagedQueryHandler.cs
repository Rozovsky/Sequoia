using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Sequoia.Data.Mongo.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodosPaged;

public class GetTodosPagedQueryHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<GetTodosPagedQuery, PagedVm<TodoHeaderVm>>
{
    public async Task<PagedVm<TodoHeaderVm>> Handle(GetTodosPagedQuery request, CancellationToken cancellationToken)
    {
        var result = await todoService.GetTodosPaged(request.Dto, cancellationToken);

        return mapper.Map<PagedVm<TodoHeaderVm>>(result);
    }
}