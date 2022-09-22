using Samples.Common.Domain.Enums;

namespace Samples.Common.Domain.Entities
{
    public class RecipeIngredient
    {
        public string Id { get; set; }
        public string IngredientId { get; set; }
        public string RecipeId { get; set; }
        public int Order { get; set; }
        public double Count { get; set; }
        public UnitType Unit { get; set; }
    }
}
