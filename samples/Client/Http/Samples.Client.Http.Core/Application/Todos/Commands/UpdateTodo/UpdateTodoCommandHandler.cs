using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoVm>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public UpdateTodoCommandHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoVm> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var result = await _todoService.UpdateTodo(request.Id, request.Dto, cancellationToken);

            return _mapper.Map<TodoVm>(result);
        }
    }
}
