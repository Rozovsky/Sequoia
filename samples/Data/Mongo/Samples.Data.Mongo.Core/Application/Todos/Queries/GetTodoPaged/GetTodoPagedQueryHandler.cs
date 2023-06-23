using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodoPaged
{
    public class GetTodoPagedQueryHandler : IRequestHandler<GetTodoPagedQuery, PagedWrapper<TodoVm>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodoPagedQueryHandler(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<PagedWrapper<TodoVm>> Handle(GetTodoPagedQuery request, CancellationToken cancellationToken)
        {
            var result = await _todoService.GetTodoPaged(request.Page, request.Limit, cancellationToken);

            return _mapper.Map<PagedWrapper<TodoVm>>(result);
        }
    }
}
