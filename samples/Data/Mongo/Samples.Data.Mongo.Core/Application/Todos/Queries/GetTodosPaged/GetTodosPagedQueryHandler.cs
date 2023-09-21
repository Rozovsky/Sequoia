using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Sequoia.Data.Mongo.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodosPaged
{
    public class GetTodosPagedQueryHandler : IRequestHandler<GetTodosPagedQuery, PagedVm<TodoHeaderVm>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodosPagedQueryHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<PagedVm<TodoHeaderVm>> Handle(GetTodosPagedQuery request, CancellationToken cancellationToken)
        {
            var result = await _todoService.GetTodosPaged(request.Dto, cancellationToken);

            return _mapper.Map<PagedVm<TodoHeaderVm>>(result);
        }
    }
}
