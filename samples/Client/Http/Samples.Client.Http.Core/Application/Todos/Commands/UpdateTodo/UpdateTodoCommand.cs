using MediatR;
using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<TodoVm>
    {
        public long Id { get; set; }
        public TodoToUpdateDto Dto { get; set; }
    }
}
