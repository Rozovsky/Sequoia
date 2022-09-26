using MediatR;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.CategoryRecipes.Commands.DeleteCategoryRecipe
{
    public class DeleteCategoryRecipeCommandHandler : AsyncRequestHandler<DeleteCategoryRecipeCommand>
    {
        private readonly ICategoryRecipeRepository _categoryRecipeRepository;

        public DeleteCategoryRecipeCommandHandler(ICategoryRecipeRepository categoryRecipeRepository)
        {
            _categoryRecipeRepository = categoryRecipeRepository;
        }

        protected override async Task Handle(DeleteCategoryRecipeCommand request, CancellationToken cancellationToken)
        {
            await _categoryRecipeRepository.DeleteCategoryRecipeAsync(request.Id, cancellationToken);
        }
    }
}
