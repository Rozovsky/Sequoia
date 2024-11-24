using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommand : IRequest<TodoVm>
{
    public TodoToCreateDto Dto { get; set; }
}