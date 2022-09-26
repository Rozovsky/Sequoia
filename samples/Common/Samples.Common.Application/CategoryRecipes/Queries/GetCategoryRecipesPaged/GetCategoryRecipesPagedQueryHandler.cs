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
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetCategoryRecipesPagedQueryHandler(
            ICategoryRecipeRepository categoryRecipeRepository,
            IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            _categoryRecipeRepository = categoryRecipeRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<PagedWrapper<CategoryRecipeVm>> Handle(GetCategoryRecipesPagedQuery request, CancellationToken cancellationToken)
        {
            var categoryRecipes = await _categoryRecipeRepository.GetCategoryRecipesPagedAsync(
                request.CategoryId, request.Page, request.Limit, cancellationToken);

            var recipesIds = categoryRecipes.Items.Select(x => x.RecipeId).ToList();
            var recipes = await _recipeRepository.GetRecipesBatchAsync(recipesIds.ToArray(), cancellationToken);

            categoryRecipes.Items.ForEach(c => c.Recipe = recipes.FirstOrDefault(p => p.Id == c.RecipeId));

            return _mapper.Map<PagedWrapper<CategoryRecipeVm>>(categoryRecipes);
        }
    }
}
