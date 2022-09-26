using AutoMapper;
using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Exceptions;

namespace Samples.Common.Application.Common.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> GetCategoryAsync(string id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryAsync(id, cancellationToken);

            if (category == null)
                throw new NotFoundException(nameof(Category), id);

            return category;
        }
    }
}
