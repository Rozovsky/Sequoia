using Samples.Common.Domain.Enums;

namespace Samples.Common.Domain.Entities
{
    public class Ingredient
    {
        public long Id { get; set; }
        public long RecipeId { get; set; }
        public int Order { get; set; }
        public double Count { get; set; }
        public UnitType Unit { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
