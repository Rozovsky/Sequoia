using MediatR;

namespace Samples.Common.Application.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public string Id { get; set; }
    }
}
