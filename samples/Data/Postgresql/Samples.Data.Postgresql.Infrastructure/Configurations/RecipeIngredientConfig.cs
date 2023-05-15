using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Postgresql.Infrastructure.Configurations
{
    public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.ToTable("recipe_ingredients");

            builder.HasKey(bc => new { bc.RecipeId, bc.IngredientId });
            //builder.HasOne(bc => bc.re)
            //    .WithMany(b => b.BookCategories)
            //    .HasForeignKey(bc => bc.BookId);
            //builder.Entity<>()
            //    .HasOne(bc => bc.Category)
            //    .WithMany(c => c.BookCategories)
            //    .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
