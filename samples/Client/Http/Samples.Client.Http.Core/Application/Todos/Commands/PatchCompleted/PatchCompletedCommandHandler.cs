using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.PatchCompleted
{
    public class PatchCompletedCommandHandler : IRequestHandler<PatchCompletedCommand, TodoVm>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public PatchCompletedCommandHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoVm> Handle(PatchCompletedCommand request, CancellationToken cancellationToken)
        {
            var result = await _todoService.PatchCompleted(request.Id, request.Dto, cancellationToken);

            return _mapper.Map<TodoVm>(result);
        }
    }
}
