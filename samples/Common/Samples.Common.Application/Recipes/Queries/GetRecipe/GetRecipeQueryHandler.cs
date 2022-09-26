using AutoMapper;
using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeVm>
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public GetRecipeQueryHandler(
            IRecipeService recipeService,
            IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        public async Task<RecipeVm> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeService.GetRecipeAsync(request.Id, cancellationToken);

            return _mapper.Map<RecipeVm>(recipe);
        }
    }
}
