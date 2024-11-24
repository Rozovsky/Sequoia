using FluentValidation;

namespace Samples.Common.Application.Categories.Queries.GetCategory;

public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .WithMessage("Id must be set");
    }
}