using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.UpdateIngredient;

public class UpdateIngredientCommandHandler(
    IIngredientRepository ingredientRepository,
    IIngredientService ingredientService,
    IMapper mapper)
    : IRequestHandler<UpdateIngredientCommand, IngredientVm>
{
    public async Task<IngredientVm> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientService.GetIngredientAsync(request.Id, cancellationToken);
        mapper.Map(request.Dto, ingredient);
        ingredient = await ingredientRepository.UpdateIngredientAsync(request.Id, ingredient, cancellationToken);

        return mapper.Map<IngredientVm>(ingredient);
    }
}