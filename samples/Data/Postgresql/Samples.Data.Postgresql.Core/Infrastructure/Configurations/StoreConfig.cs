using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Infrastructure.Configurations
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasMany(c => c.CoffeeMachines);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(t => t.Type)
                .HasConversion<string>()
                .HasMaxLength(64);
        }
    }
}
