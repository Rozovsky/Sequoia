using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class RecipeRepository : PostgresRepository<Category>, IRecipeRepository
    {
        public RecipeRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
