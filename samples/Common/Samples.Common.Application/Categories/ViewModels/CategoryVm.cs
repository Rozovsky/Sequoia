using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Categories.ViewModels;

[AutoMap(typeof(Category))]
public class CategoryVm
{
    public string Id { get; set; }
    public string Name { get; set; }
    //public List<Recipe> Recipes { get; set; }
}