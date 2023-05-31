using MediatR;
using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<TodoVm>
    {
        public TodoToCreateDto Dto { get; set; }
    }
}
