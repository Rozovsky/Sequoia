namespace Samples.Common.Domain.Entities;

public class CategoryRecipe
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}