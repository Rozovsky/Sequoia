using FluentValidation;

namespace Samples.Common.Application.Ingredients.Queries.GetIngredientsPaged
{
    public class GetIngredientsPagedQueryValidator : AbstractValidator<GetIngredientsPagedQuery>
    {
        public GetIngredientsPagedQueryValidator()
        {
            RuleFor(v => v.Page)
                .GreaterThan(0)
                    .WithMessage("Page must be greater than 0");

            RuleFor(v => v.Limit)
                .GreaterThan(0)
                    .WithMessage("Limit must be greater than 0");
        }
    }
}
