using MediatR;
using Samples.Common.Application.Ingredients.ViewModels;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQuery : IRequest<IngredientVm>
    {
        public string Id { get; set; }
    }
}
