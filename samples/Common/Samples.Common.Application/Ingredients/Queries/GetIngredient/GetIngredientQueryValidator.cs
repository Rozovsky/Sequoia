using FluentValidation;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQueryValidator : AbstractValidator<GetIngredientQuery>
    {
        public GetIngredientQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotNull()
                    .WithMessage("Id must be set");
        }
    }
}
