using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Infrastructure.Configurations
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("ingredients");

            builder.HasIndex(c => c.Name);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
