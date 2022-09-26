using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesBatch
{
    public class GetRecipesBatchQueryHandler : IRequestHandler<GetRecipesBatchQuery, List<RecipeVm>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipesBatchQueryHandler(
            IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeVm>> Handle(GetRecipesBatchQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipesBatchAsync(request.Ids, cancellationToken);

            return _mapper.Map<List<RecipeVm>>(recipes);
        }
    }
}
