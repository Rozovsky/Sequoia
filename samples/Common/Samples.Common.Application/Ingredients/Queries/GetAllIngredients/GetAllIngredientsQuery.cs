using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;

namespace Samples.Common.Application.Ingredients.Queries.GetAllIngredients
{
    public class GetAllIngredientsQuery : IRequest<List<IngredientVm>>
    {
    }
}
