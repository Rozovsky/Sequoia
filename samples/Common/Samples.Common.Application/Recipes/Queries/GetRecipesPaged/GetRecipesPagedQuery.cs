using MediatR;
using Samples.Common.Application.Recipes.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesPaged
{
    public class GetRecipesPagedQuery : IRequest<PagedWrapper<RecipeVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
