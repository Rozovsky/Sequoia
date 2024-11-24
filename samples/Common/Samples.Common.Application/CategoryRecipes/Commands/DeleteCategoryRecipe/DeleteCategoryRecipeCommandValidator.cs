using FluentValidation;

namespace Samples.Common.Application.CategoryRecipes.Commands.DeleteCategoryRecipe;

public class DeleteCategoryRecipeCommandValidator : AbstractValidator<DeleteCategoryRecipeCommand>
{
    public DeleteCategoryRecipeCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .WithMessage("Id must be set");
    }
}