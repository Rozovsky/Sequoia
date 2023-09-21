using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<TodoVm>
    {
        public string Id { get; set; }
        public TodoToUpdateDto Dto { get; set; }
    }
}
