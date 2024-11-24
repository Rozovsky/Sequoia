using AutoMapper;
using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Exceptions;

namespace Samples.Common.Application.Common.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IMapper mapper) : ICategoryService
{
    private readonly IMapper _mapper = mapper;

    public async Task<Category> GetCategoryAsync(string id, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryAsync(id, cancellationToken);

        if (category == null)
            throw new NotFoundException(nameof(Category), id);

        return category;
    }
}