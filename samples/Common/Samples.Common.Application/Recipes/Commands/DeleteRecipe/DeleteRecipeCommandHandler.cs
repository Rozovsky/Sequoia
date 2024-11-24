using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.DeleteRecipe;

public class DeleteRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IRecipeService recipeService)
    : IRequestHandler<DeleteRecipeCommand>
{
    public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await recipeService.GetRecipeAsync(request.Id, cancellationToken);
        await recipeRepository.DeleteRecipeAsync(recipe.Id, cancellationToken);
    }
}