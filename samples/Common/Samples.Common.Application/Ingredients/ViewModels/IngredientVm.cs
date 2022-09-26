using AutoMapper;
using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Ingredients.ViewModels
{
    [AutoMap(typeof(Ingredient))]
    public class IngredientVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
