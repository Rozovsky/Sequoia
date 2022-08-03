using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Infrastructure.Configurations
{
    public class CoffeeMachineConfig : IEntityTypeConfiguration<CoffeeMachine>
    {
        public void Configure(EntityTypeBuilder<CoffeeMachine> builder)
        {
            builder.ToTable("CoffeeMachines");

            builder.Property(t => t.Brand)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(t => t.Model)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
