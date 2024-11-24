using FluentValidation;

namespace Samples.Common.Application.CategoryRecipes.Commands.CreateCategoryRecipe;

public class CreateCategoryRecipeCommandValidator : AbstractValidator<CreateCategoryRecipeCommand>
{
    public CreateCategoryRecipeCommandValidator()
    {
        RuleFor(v => v.Dto.RecipeId)
            .NotNull()
            .WithMessage("RecipeId must be set");

        RuleFor(v => v.Dto.CategoryId)
            .NotNull()
            .WithMessage("CategoryId must be set");
    }
}