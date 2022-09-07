namespace Samples.Common.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
