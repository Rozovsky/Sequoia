using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoVm>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoVm> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var result = await _todoService.CreateTodo(request.Dto, cancellationToken);

            return _mapper.Map<TodoVm>(result);
        }
    }
}
