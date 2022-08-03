using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Shop> Shops { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
