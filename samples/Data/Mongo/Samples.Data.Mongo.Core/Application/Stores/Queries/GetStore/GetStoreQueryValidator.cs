using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQueryValidator : AbstractValidator<GetStoreQuery>
    {
        public GetStoreQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                    .WithMessage("Id must be set");
        }
    }
}
