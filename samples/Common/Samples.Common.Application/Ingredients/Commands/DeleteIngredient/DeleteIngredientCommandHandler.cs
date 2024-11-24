using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.DeleteIngredient;

public class DeleteIngredientCommandHandler(
    IIngredientRepository ingredientRepository,
    IIngredientService ingredientService)
    : IRequestHandler<DeleteIngredientCommand>
{
    public async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientService.GetIngredientAsync(request.Id, cancellationToken);
        await ingredientRepository.DeleteIngredientAsync(ingredient.Id, cancellationToken);
    }
}