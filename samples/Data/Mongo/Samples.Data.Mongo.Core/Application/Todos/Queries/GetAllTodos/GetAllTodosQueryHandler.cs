using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoVm>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetAllTodosQueryHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<List<TodoVm>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var result = await _todoService.GetAllTodos(cancellationToken);

            return _mapper.Map<List<TodoVm>>(result);
        }
    }
}
