using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Recipes.Dtos;

[AutoMap(typeof(Recipe), ReverseMap = true)]
public class RecipeToCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}