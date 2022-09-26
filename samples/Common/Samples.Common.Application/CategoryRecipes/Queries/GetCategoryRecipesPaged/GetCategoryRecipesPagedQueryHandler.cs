using AutoMapper;
using MediatR;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.CategoryRecipes.Queries.GetCategoryRecipesPaged
{
    public class GetCategoryRecipesPagedQueryHandler : IRequestHandler<GetCategoryRecipesPagedQuery, PagedWrapper<CategoryRecipeVm>>
    {
        private readonly ICategoryRecipeRepository _categoryRecipeRepository;
        private readonly IMapper _mapper;

        public GetCategoryRecipesPagedQueryHandler(
            ICategoryRecipeRepository categoryRecipeRepository,
            IMapper mapper)
        {
            _categoryRecipeRepository = categoryRecipeRepository;
            _mapper = mapper;
        }

        public async Task<PagedWrapper<CategoryRecipeVm>> Handle(GetCategoryRecipesPagedQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRecipeRepository.GetCategoryRecipesPagedAsync(
                request.CategoryId, request.Page, request.Limit, cancellationToken);

            return _mapper.Map<PagedWrapper<CategoryRecipeVm>>(category);
        }
    }
}
