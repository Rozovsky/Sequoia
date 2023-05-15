using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Postgresql.Infrastructure.Configurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("recipes");

            builder.HasIndex(c => c.Name);

            builder.HasMany(c => c.Ingredients);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
