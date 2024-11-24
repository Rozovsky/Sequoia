using FluentValidation;

namespace Samples.Common.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
{
    public UpdateRecipeCommandValidator()
    {
        RuleFor(v => v.Dto.Name)
            .MaximumLength(64)
            .WithMessage("Name maximum length is 64")
            .NotEmpty()
            .WithMessage("Name must be set");
    }
}