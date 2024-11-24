using MediatR;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    ICategoryService categoryService)
    : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryService.GetCategoryAsync(request.Id, cancellationToken);
        await categoryRepository.DeleteCategoryAsync(category.Id, cancellationToken);
    }
}