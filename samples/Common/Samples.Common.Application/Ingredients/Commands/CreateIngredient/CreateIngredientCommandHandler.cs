using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.CreateIngredient;

public class CreateIngredientCommandHandler(
    IIngredientRepository ingredientRepository,
    IMapper mapper)
    : IRequestHandler<CreateIngredientCommand, IngredientVm>
{
    public async Task<IngredientVm> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientRepository.CreateIngredientAsync(
            mapper.Map<Ingredient>(request.Dto), cancellationToken);

        return mapper.Map<IngredientVm>(ingredient);
    }
}