using Microsoft.EntityFrameworkCore;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<CoffeeEntity> Coffee { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
