using MediatR;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodoPaged
{
    public class GetTodoPagedQuery : IRequest<PagedWrapper<TodoVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
