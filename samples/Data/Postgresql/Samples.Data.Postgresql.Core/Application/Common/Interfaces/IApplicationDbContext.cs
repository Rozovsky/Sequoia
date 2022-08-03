using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Store> Shops { get; set; }
        DbSet<CoffeeMachine> CoffeeMachines { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
