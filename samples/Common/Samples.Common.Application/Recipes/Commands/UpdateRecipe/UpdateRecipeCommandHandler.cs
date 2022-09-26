using AutoMapper;
using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, RecipeVm>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public UpdateRecipeCommandHandler(
            IRecipeRepository recipeRepository,
            IRecipeService recipeService,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _recipeService = recipeService;
            _mapper = mapper;
        }

        public async Task<RecipeVm> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeService.GetRecipeAsync(request.Id, cancellationToken);
            _mapper.Map(request.Dto, recipe);
            recipe = await _recipeRepository.UpdateRecipeAsync(request.Id, recipe, cancellationToken);

            return _mapper.Map<RecipeVm>(recipe);
        }
    }
}
