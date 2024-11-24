using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    ICategoryService categoryService,
    IMapper mapper)
    : IRequestHandler<UpdateCategoryCommand, CategoryVm>
{
    public async Task<CategoryVm> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryService.GetCategoryAsync(request.Id, cancellationToken);
        mapper.Map(request.Dto, category);
        category = await categoryRepository.UpdateCategoryAsync(request.Id, category, cancellationToken);

        return mapper.Map<CategoryVm>(category);
    }
}