using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Recipes.Dtos;

[AutoMap(typeof(Recipe), ReverseMap = true)]
public class RecipeToUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}