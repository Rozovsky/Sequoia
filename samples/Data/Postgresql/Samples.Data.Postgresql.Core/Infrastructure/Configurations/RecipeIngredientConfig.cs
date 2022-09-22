using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samples.Common.Domain.Entities;
using System.Reflection.Emit;

namespace Samples.Data.Postgresql.Core.Infrastructure.Configurations
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
