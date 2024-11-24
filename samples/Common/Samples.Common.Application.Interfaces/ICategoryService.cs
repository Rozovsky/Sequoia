using Samples.Common.Domain.Entities;

namespace Samples.Common.Application.Interfaces;

public interface ICategoryService
{
    Task<Category> GetCategoryAsync(string id, CancellationToken cancellationToken);
}