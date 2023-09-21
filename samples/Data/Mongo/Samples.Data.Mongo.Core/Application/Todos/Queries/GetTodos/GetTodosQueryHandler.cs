using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodos
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoVm>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<List<TodoVm>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var result = await _todoService.GetTodos(cancellationToken);

            return _mapper.Map<List<TodoVm>>(result);
        }
    }
}
