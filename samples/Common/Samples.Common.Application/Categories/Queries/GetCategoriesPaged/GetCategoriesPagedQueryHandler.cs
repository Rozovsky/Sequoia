using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Categories.Queries.GetCategoriesPaged
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, Paged<CategoryVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesPagedQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Paged<CategoryVm>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoriesPagedAsync(
                request.Page, request.Limit, cancellationToken);

            return _mapper.Map<Paged<CategoryVm>>(category);
        }
    }
}
