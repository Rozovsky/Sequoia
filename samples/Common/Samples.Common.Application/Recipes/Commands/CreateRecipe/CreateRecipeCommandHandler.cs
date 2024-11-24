using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IMapper mapper) : IRequestHandler<CreateRecipeCommand, RecipeVm>
{
    public async Task<RecipeVm> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await recipeRepository.CreateRecipeAsync(
            mapper.Map<Recipe>(request.Dto), cancellationToken);

        return mapper.Map<RecipeVm>(recipe);
    }
}