using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<UpdateTodoCommand, TodoVm>
{
    public async Task<TodoVm> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var result = await todoService.UpdateTodo(request.Id, request.Dto, cancellationToken);

        return mapper.Map<TodoVm>(result);
    }
}