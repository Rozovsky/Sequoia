using MediatR;
using Samples.Common.Application.Recipes.ViewModels;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesBatch
{
    public class GetRecipesBatchQuery : IRequest<List<RecipeVm>>
    {
        public string[] Ids { get; set; }
    }
}
