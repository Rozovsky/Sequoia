using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Application.Interfaces;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredient;

public class GetIngredientQueryHandler(
    IIngredientService ingredientService,
    IMapper mapper) : IRequestHandler<GetIngredientQuery, IngredientVm>
{
    public async Task<IngredientVm> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientService.GetIngredientAsync(request.Id, cancellationToken);

        return mapper.Map<IngredientVm>(ingredient);
    }
}