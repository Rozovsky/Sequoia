using AutoMapper;
using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientVm>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public CreateIngredientCommandHandler(
            IIngredientRepository ingredientRepository,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IngredientVm> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.CreateIngredientAsync(
                _mapper.Map<Ingredient>(request.Dto), cancellationToken);

            return _mapper.Map<IngredientVm>(ingredient);
        }
    }
}
