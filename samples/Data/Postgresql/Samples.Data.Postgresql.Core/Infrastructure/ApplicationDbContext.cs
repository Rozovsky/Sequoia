using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using System.Reflection;
using Sequoia.Interfaces;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Samples.Data.Postgresql.Core.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<CoffeeMachine> CoffeeMachines { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IEntityAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateOfCreation = DateTimeOffset.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.DateOfModification = DateTimeOffset.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
