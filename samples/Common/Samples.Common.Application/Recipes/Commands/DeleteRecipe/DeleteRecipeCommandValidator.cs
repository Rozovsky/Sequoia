using FluentValidation;

namespace Samples.Common.Application.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
    {
        public DeleteRecipeCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull()
                    .WithMessage("Id must be set");
        }
    }
}
