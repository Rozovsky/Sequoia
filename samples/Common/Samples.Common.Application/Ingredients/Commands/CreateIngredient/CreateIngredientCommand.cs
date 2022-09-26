using MediatR;
using Samples.Common.Application.Ingredients.Dtos;
using Samples.Common.Application.Ingredients.ViewModels;

namespace Samples.Common.Application.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : IRequest<IngredientVm>
    {
        public IngredientToCreateDto Dto { get; set; }
    }
}
