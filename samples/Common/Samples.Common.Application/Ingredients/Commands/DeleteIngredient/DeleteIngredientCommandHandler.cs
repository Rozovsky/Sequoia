using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandHandler : AsyncRequestHandler<DeleteIngredientCommand>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientService _ingredientService;

        public DeleteIngredientCommandHandler(
            IIngredientRepository ingredientRepository,
            IIngredientService ingredientService)
        {
            _ingredientRepository = ingredientRepository;
            _ingredientService = ingredientService;
        }

        protected override async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientService.GetIngredientAsync(request.Id, cancellationToken);
            await _ingredientRepository.DeleteIngredientAsync(ingredient.Id, cancellationToken);
        }
    }
}
