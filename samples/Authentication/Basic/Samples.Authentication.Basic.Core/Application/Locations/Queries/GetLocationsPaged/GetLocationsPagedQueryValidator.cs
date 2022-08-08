using FluentValidation;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged
{
    public class GetLocationsPagedQueryValidator : AbstractValidator<GetLocationsPagedQuery>
    {
        public GetLocationsPagedQueryValidator()
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
