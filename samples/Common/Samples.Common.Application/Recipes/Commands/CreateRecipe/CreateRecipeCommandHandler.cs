using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, RecipeVm>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public CreateRecipeCommandHandler(
            IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<RecipeVm> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.CreateRecipeAsync(
                _mapper.Map<Recipe>(request.Dto), cancellationToken);

            return _mapper.Map<RecipeVm>(recipe);
        }
    }
}
