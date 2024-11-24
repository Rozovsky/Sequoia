using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.CategoryRecipes.Dtos;

[AutoMap(typeof(CategoryRecipe), ReverseMap = true)]
public class CategoryRecipeToUpdateDto
{
    public string CategoryId { get; set; }
    public string RecipeId { get; set; }
}