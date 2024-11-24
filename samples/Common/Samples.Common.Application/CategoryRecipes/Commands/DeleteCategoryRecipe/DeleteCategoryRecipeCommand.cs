using MediatR;

namespace Samples.Common.Application.CategoryRecipes.Commands.DeleteCategoryRecipe;

public class DeleteCategoryRecipeCommand : IRequest
{
    public string Id { get; set; }
}