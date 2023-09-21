using AutoMapper;
using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesPaged
{
    public class GetRecipesPagedQueryHandler : IRequestHandler<GetRecipesPagedQuery, Paged<RecipeVm>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipesPagedQueryHandler(
            IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<Paged<RecipeVm>> Handle(GetRecipesPagedQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipesPagedAsync(
                request.Page, request.Limit, cancellationToken);

            return _mapper.Map<Paged<RecipeVm>>(recipes);
        }
    }
}
