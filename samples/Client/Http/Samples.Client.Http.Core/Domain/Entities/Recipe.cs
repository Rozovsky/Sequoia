namespace Samples.Client.Http.Core.Domain.Entities
{
    public class Recipe
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public double Rating { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
