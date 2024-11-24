namespace Samples.Common.Domain.Entities;

public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<CategoryRecipe> Recipes { get; set; }
}