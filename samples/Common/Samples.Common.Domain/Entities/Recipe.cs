﻿namespace Samples.Common.Domain.Entities;

public class Recipe
{
    public string Id { get; set; }
    public double Rating { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
}