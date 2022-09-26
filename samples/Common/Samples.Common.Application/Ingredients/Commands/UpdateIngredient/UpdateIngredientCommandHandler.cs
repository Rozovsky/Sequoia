using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, IngredientVm>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public UpdateIngredientCommandHandler(
            IIngredientRepository ingredientRepository,
            IIngredientService ingredientService,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        public async Task<IngredientVm> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientService.GetIngredientAsync(request.Id, cancellationToken);
            _mapper.Map(request.Dto, ingredient);
            ingredient = await _ingredientRepository.UpdateIngredientAsync(request.Id, ingredient, cancellationToken);

            return _mapper.Map<IngredientVm>(ingredient);
        }
    }
}
