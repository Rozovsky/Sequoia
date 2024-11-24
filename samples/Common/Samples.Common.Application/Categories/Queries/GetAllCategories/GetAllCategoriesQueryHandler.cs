using AutoMapper;
using MediatR;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Infrastructure.Interfaces;

namespace Samples.Common.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, List<CategoryVm>>
{
    public async Task<List<CategoryVm>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllCategoriesAsync(cancellationToken);

        return mapper.Map<List<CategoryVm>>(categories);
    }
}