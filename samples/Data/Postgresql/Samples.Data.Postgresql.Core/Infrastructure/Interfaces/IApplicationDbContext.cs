using Microsoft.EntityFrameworkCore;
using Samples.Common.Domain.Entities;
using Sequoia.Data.Postgresql.Interfaces;

namespace Samples.Data.Postgresql.Core.Infrastructure.Interfaces
{
    public interface IApplicationDbContext : IPostgresContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
    }
}
