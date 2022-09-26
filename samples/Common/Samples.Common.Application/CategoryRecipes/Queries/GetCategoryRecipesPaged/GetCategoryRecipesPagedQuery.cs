using MediatR;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Common.Application.CategoryRecipes.Queries.GetCategoryRecipesPaged
{
    public class GetCategoryRecipesPagedQuery : IRequest<PagedWrapper<CategoryRecipeVm>>
    {
        public string CategoryId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
