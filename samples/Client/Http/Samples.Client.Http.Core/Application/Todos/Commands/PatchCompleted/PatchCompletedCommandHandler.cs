using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.PatchCompleted;

public class PatchCompletedCommandHandler(
    ITodoService todoService,
    IMapper mapper) : IRequestHandler<PatchCompletedCommand, TodoVm>
{
    public async Task<TodoVm> Handle(PatchCompletedCommand request, CancellationToken cancellationToken)
    {
        var result = await todoService.PatchCompleted(request.Id, request.Dto, cancellationToken);

        return mapper.Map<TodoVm>(result);
    }
}