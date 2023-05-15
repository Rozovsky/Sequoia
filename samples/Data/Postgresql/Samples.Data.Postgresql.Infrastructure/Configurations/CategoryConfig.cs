using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.Common.Domain.Entities;

namespace Samples.Data.Postgresql.Infrastructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasMany(c => c.Recipes);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
