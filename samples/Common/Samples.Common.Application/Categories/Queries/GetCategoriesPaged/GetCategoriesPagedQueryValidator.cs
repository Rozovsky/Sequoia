using FluentValidation;

namespace Samples.Common.Application.Categories.Queries.GetCategoriesPaged;

public class GetCategoriesPagedQueryValidator : AbstractValidator<GetCategoriesPagedQuery>
{
    public GetCategoriesPagedQueryValidator()
    {
        RuleFor(v => v.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0");

        RuleFor(v => v.Limit)
            .GreaterThan(0)
            .WithMessage("Limit must be greater than 0");
    }
}