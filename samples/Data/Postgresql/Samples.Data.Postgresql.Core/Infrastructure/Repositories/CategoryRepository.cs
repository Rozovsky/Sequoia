using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Postgresql.Core.Infrastructure.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Repositories;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class CategoryRepository : PostgresRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> CreateCategoryAsync(Category obj, CancellationToken cancellationToken)
        {
            return await base.CreateAsync(obj, cancellationToken);
        }

        public async Task<Category> UpdateCategoryAsync(string id, Category obj, CancellationToken cancellationToken)
        {
            return await base.UpdateAsync(c => c.Id == id, obj, cancellationToken);
        }

        public async Task DeleteCategoryAsync(string id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task<PagedWrapper<Category>> GetCategoriesPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            return await base.GetPagedAsync(page, limit, cancellationToken);
        }

        public async Task<Category> GetCategoryAsync(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }
    }
}
