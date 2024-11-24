using FluentValidation;

namespace Samples.Common.Application.CategoryRecipes.Queries.GetCategoryRecipesPaged;

public class GetCategoryRecipesPagedQueryValidator : AbstractValidator<GetCategoryRecipesPagedQuery>
{
    public GetCategoryRecipesPagedQueryValidator()
    {
        RuleFor(v => v.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0");

        RuleFor(v => v.Limit)
            .GreaterThan(0)
            .WithMessage("Limit must be greater than 0");

        RuleFor(v => v.CategoryId)
            .NotNull()
            .WithMessage("CategoryId must be set");
    }
}