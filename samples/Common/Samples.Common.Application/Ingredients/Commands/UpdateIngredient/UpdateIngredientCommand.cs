using MediatR;
using Samples.Common.Application.Ingredients.Dtos;
using Samples.Common.Application.Ingredients.ViewModels;

namespace Samples.Common.Application.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommand : IRequest<IngredientVm>
    {
        public string Id { get; set; }
        public IngredientToUpdateDto Dto { get; set; }
    }
}
