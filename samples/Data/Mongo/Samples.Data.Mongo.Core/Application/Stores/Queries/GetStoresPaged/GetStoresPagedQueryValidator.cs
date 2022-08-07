using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStoresPaged
{
    public class GetStoresPagedQueryValidator : AbstractValidator<GetStoresPagedQuery>
    {
        public GetStoresPagedQueryValidator()
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
