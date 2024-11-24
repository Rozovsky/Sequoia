using FluentValidation;

namespace Samples.Common.Application.Ingredients.Commands.CreateIngredient;

public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator()
    {
        RuleFor(v => v.Dto.Name)
            .MaximumLength(64)
            .WithMessage("Name maximum length is 64")
            .NotEmpty()
            .WithMessage("Name must be set");
    }
}