using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Queries.GetAllIngredients;

public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, List<IngredientVm>>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public GetAllIngredientsQueryHandler(
        IIngredientRepository ingredientRepository,
        IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }

    public async Task<List<IngredientVm>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await _ingredientRepository.GetAllIngredientsAsync(cancellationToken);

        return _mapper.Map<List<IngredientVm>>(ingredients);
    }
}