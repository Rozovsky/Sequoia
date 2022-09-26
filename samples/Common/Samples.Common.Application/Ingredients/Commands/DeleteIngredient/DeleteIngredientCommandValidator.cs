using FluentValidation;

namespace Samples.Common.Application.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
    {
        public DeleteIngredientCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull()
                    .WithMessage("Id must be set");
        }
    }
}
