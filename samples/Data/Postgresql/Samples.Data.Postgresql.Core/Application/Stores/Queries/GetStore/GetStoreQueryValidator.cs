using FluentValidation;

namespace Samples.Data.Postgresql.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQueryValidator : AbstractValidator<GetStoreQuery>
    {
        public GetStoreQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");
        }
    }
}
