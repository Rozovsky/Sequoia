using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<CreateTodoCommand, TodoVm>
{
    public async Task<TodoVm> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var result = await todoService.CreateTodo(request.Dto, cancellationToken);

        return mapper.Map<TodoVm>(result);
    }
}