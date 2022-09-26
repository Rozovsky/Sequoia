using FluentValidation;

namespace Samples.Common.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQueryValidator : AbstractValidator<GetRecipeQuery>
    {
        public GetRecipeQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotNull()
                    .WithMessage("Id must be set");
        }
    }
}
