using FluentValidation;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesPaged
{
    public class GetRecipesPagedQueryValidator : AbstractValidator<GetRecipesPagedQuery>
    {
        public GetRecipesPagedQueryValidator()
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
