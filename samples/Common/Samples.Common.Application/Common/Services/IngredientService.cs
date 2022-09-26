using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Exceptions;

namespace Samples.Common.Application.Common.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Ingredient> GetIngredientAsync(string id, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(id, cancellationToken);

            if (ingredient == null)
                throw new NotFoundException(nameof(Ingredient), id);

            return ingredient;
        }
    }
}
