using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Infrastructure.Configurations;

public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("recipe_ingredients");

        builder.HasKey(bc => new { bc.RecipeId, bc.IngredientId });
    }
}