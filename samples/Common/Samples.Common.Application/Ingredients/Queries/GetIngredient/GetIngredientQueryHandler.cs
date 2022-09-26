using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Application.Interfaces;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, IngredientVm>
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public GetIngredientQueryHandler(
            IIngredientService ingredientService,
            IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        public async Task<IngredientVm> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientService.GetIngredientAsync(request.Id, cancellationToken);

            return _mapper.Map<IngredientVm>(ingredient);
        }
    }
}
