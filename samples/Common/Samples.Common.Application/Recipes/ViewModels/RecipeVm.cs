using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Recipes.ViewModels;

[AutoMap(typeof(Recipe))]
public class RecipeVm
{
    public string Id { get; set; }
    public double Rating { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    //public List<RecipeIngredient> Ingredients { get; set; }
}