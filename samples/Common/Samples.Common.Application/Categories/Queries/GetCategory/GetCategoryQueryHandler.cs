using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Application.Interfaces;

namespace Samples.Common.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVm>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(
            ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryVm> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryAsync(request.Id, cancellationToken);

            return _mapper.Map<CategoryVm>(category);
        }
    }
}
