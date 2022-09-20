using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : AsyncRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        protected override async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryAsync(request.Id, cancellationToken);
            await _categoryRepository.DeleteCategoryAsync(category.Id, cancellationToken);
        }
    }
}
