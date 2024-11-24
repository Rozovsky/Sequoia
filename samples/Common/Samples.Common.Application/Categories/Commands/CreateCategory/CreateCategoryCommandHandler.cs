using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, CategoryVm>
{
    public async Task<CategoryVm> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.CreateCategoryAsync(
            mapper.Map<Category>(request.Dto), cancellationToken);

        return mapper.Map<CategoryVm>(category);
    }
}