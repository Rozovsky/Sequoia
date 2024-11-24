using FluentValidation;

namespace Samples.Common.Application.Ingredients.Commands.UpdateIngredient;

public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    public UpdateIngredientCommandValidator()
    {
        RuleFor(v => v.Dto.Name)
            .MaximumLength(64)
            .WithMessage("Name maximum length is 64")
            .NotEmpty()
            .WithMessage("Name must be set");
    }
}