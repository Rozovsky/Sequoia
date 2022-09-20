using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryVm>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync(cancellationToken);

            return _mapper.Map<List<CategoryVm>>(categories);
        }
    }
}
