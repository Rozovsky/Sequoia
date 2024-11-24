using AutoMapper;
using MediatR;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.CategoryRecipes.Commands.CreateCategoryRecipe;

public class CreateCategoryRecipeCommandHandler(
    ICategoryRecipeRepository categoryRecipeRepository,
    ICategoryService categoryService,
    IRecipeService recipeService,
    IMapper mapper)
    : IRequestHandler<CreateCategoryRecipeCommand, CategoryRecipeVm>
{
    public async Task<CategoryRecipeVm> Handle(CreateCategoryRecipeCommand request, CancellationToken cancellationToken)
    {
        // check category and recipe exist
        await categoryService.GetCategoryAsync(request.Dto.CategoryId, cancellationToken);
        await recipeService.GetRecipeAsync(request.Dto.RecipeId, cancellationToken);

        var categoryRecipe = await categoryRecipeRepository.CreateCategoryRecipeAsync(
            mapper.Map<CategoryRecipe>(request.Dto), cancellationToken);

        return mapper.Map<CategoryRecipeVm>(categoryRecipe);
    }
}