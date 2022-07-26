using Microsoft.EntityFrameworkCore;
using Samples.Sequoia.Complex.Core.Application.Common.Interfaces;
using System.Reflection;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CoffeeEntity> Coffee { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}
