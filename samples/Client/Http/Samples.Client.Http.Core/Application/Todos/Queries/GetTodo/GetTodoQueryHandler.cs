using AutoMapper;
using MediatR;
using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Application.Common.ViewModels;

namespace Samples.Client.Http.Core.Application.Todos.Queries.GetTodo
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoVm>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodoQueryHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<TodoVm> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var result = await _todoService.GetTodo(request.Id, cancellationToken);

            return _mapper.Map<TodoVm>(result);
        }
    }
}
