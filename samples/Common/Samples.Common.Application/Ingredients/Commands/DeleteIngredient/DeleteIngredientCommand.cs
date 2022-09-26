using MediatR;

namespace Samples.Common.Application.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public string Id { get; set; }
    }
}
