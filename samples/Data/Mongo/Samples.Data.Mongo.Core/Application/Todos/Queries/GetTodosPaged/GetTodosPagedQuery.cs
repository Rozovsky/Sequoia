using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Sequoia.Data.Mongo.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodosPaged;

public class GetTodosPagedQuery : IRequest<PagedVm<TodoHeaderVm>>
{
    public TodoToPagedDto Dto { get; set; }
}