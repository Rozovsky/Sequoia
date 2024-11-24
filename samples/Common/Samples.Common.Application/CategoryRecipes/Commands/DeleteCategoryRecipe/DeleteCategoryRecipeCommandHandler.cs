using MediatR;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.CategoryRecipes.Commands.DeleteCategoryRecipe;

public class DeleteCategoryRecipeCommandHandler(ICategoryRecipeRepository categoryRecipeRepository)
    : IRequestHandler<DeleteCategoryRecipeCommand>
{
    public async Task Handle(DeleteCategoryRecipeCommand request, CancellationToken cancellationToken)
    {
        await categoryRecipeRepository.DeleteCategoryRecipeAsync(request.Id, cancellationToken);
    }
}