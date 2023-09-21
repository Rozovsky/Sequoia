using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredientsPaged
{
    public class GetIngredientsPagedQueryHandler : IRequestHandler<GetIngredientsPagedQuery, Paged<IngredientVm>>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public GetIngredientsPagedQueryHandler(
            IIngredientRepository ingredientRepository,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<Paged<IngredientVm>> Handle(GetIngredientsPagedQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await _ingredientRepository.GetIngredientsPagedAsync(
                request.Page, request.Limit, cancellationToken);

            return _mapper.Map<Paged<IngredientVm>>(ingredients);
        }
    }
}
