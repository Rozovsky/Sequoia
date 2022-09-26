using AutoMapper;
using MediatR;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.CategoryRecipes.Commands.CreateCategoryRecipe
{
    public class CreateCategoryRecipeCommandHandler : IRequestHandler<CreateCategoryRecipeCommand, CategoryRecipeVm>
    {
        private readonly ICategoryRecipeRepository _categoryRecipeRepository;
        private readonly ICategoryService _categoryService;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public CreateCategoryRecipeCommandHandler(
            ICategoryRecipeRepository categoryRecipeRepository,
            ICategoryService categoryService,
             IRecipeService recipeService,
            IMapper mapper)
        {
            _categoryRecipeRepository = categoryRecipeRepository;
            _categoryService = categoryService;
            _recipeService = recipeService;
            _mapper = mapper;
        }

        public async Task<CategoryRecipeVm> Handle(CreateCategoryRecipeCommand request, CancellationToken cancellationToken)
        {
            // check category and recipe exist
            await _categoryService.GetCategoryAsync(request.Dto.CategoryId, cancellationToken);
            await _recipeService.GetRecipeAsync(request.Dto.RecipeId, cancellationToken);

            var categoryRecipe = await _categoryRecipeRepository.CreateCategoryRecipeAsync(
                _mapper.Map<CategoryRecipe>(request.Dto), cancellationToken);

            return _mapper.Map<CategoryRecipeVm>(categoryRecipe);
        }
    }
}
