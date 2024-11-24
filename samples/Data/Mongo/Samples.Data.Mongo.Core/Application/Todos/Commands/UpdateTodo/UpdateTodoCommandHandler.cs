using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Commands.UpdateTodo;

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