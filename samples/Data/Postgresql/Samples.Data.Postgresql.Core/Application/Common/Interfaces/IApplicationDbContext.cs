using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Data.Postgresql.Interfaces;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IPostgresContext
    {
        DbSet<Store> Stores { get; set; }
        DbSet<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
