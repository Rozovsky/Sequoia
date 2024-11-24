using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredientsPaged;

public class GetIngredientsPagedQueryHandler(
    IIngredientRepository ingredientRepository,
    IMapper mapper)
    : IRequestHandler<GetIngredientsPagedQuery, Paged<IngredientVm>>
{
    public async Task<Paged<IngredientVm>> Handle(GetIngredientsPagedQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await ingredientRepository.GetIngredientsPagedAsync(
            request.Page, request.Limit, cancellationToken);

        return mapper.Map<Paged<IngredientVm>>(ingredients);
    }
}