using FluentValidation;

namespace Samples.Common.Application.Recipes.Queries.GetRecipesBatch;

public class GetRecipesBatchQueryValidator : AbstractValidator<GetRecipesBatchQuery>
{
    public GetRecipesBatchQueryValidator()
    {
        RuleFor(v => v.Ids)
            .NotEmpty()
            .WithMessage("Ids must be not empty")
            .NotNull()
            .WithMessage("Ids must be set");
                
    }
}