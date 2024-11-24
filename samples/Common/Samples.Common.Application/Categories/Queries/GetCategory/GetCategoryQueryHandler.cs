using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Application.Interfaces;

namespace Samples.Common.Application.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler(
    ICategoryService categoryService,
    IMapper mapper) : IRequestHandler<GetCategoryQuery, CategoryVm>
{
    public async Task<CategoryVm> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryService.GetCategoryAsync(request.Id, cancellationToken);

        return mapper.Map<CategoryVm>(category);
    }
}