using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : AsyncRequestHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeService _recipeService;

        public DeleteRecipeCommandHandler(
            IRecipeRepository recipeRepository,
            IRecipeService recipeService)
        {
            _recipeRepository = recipeRepository;
            _recipeService = recipeService;
        }

        protected override async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeService.GetRecipeAsync(request.Id, cancellationToken);
            await _recipeRepository.DeleteRecipeAsync(recipe.Id, cancellationToken);
        }
    }
}
