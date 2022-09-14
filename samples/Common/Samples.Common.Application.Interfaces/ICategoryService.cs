using Samples.Common.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Interfaces
{
    public interface ICategoryService
    {
        //Task<Category> CreateCategoryAsync(CategoryToCreateDto dto, CancellationToken cancellationToken);
        Task<Category> UpdateCategoryAsync(long id, Category obj, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(long id, CancellationToken cancellationToken);
        Task<Category> GetCategoryAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<PagedWrapper<Category>> GetCategoriesPagedAsync(int page, int limit, CancellationToken cancellationToken);
    }
}
