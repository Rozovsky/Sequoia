using FluentValidation;

namespace Samples.Common.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(v => v.Dto.Name)
                .MaximumLength(64)
                    .WithMessage("Name maximum length is 64")
                .NotEmpty()
                    .WithMessage("Name must be set");
        }
    }
}
