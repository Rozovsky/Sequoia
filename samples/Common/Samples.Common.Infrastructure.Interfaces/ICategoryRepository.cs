using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateCategoryAsync(Category obj, CancellationToken cancellationToken);
    Task<Category> UpdateCategoryAsync(string id, Category obj, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(string id, CancellationToken cancellationToken);
    Task<Category> GetCategoryAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    Task<Paged<Category>> GetCategoriesPagedAsync(int page, int limit, CancellationToken cancellationToken);
}