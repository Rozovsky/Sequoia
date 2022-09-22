using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class IngredientRepository : PostgresRepository<Category>, IIngredientRepository
    {
        public IngredientRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}