using AutoMapper;
using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IRecipeService recipeService,
    IMapper mapper)
    : IRequestHandler<UpdateRecipeCommand, RecipeVm>
{
    public async Task<RecipeVm> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await recipeService.GetRecipeAsync(request.Id, cancellationToken);
        mapper.Map(request.Dto, recipe);
        recipe = await recipeRepository.UpdateRecipeAsync(request.Id, recipe, cancellationToken);

        return mapper.Map<RecipeVm>(recipe);
    }
}