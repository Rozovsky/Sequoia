using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.CreateTodo;

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