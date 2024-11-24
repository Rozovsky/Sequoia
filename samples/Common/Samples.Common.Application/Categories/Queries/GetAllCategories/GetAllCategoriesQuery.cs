using MediatR;
using Samples.Common.Application.Categories.ViewModels;

namespace Samples.Common.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryVm>>
{
}