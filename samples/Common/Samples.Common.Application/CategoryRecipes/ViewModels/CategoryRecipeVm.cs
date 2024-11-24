using AutoMapper;
using Samples.Common.Application.Recipes.ViewModels;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.CategoryRecipes.ViewModels;

[AutoMap(typeof(CategoryRecipe))]
public class CategoryRecipeVm
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string RecipeId { get; set; }
    public RecipeVm Recipe { get; set; }
}