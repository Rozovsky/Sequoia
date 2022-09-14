using FluentValidation;

namespace Samples.Common.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.Dto.Name)
                .MaximumLength(64)
                    .WithMessage("Name maximum length is 64")
                .NotEmpty()
                    .WithMessage("Name must be set");
        }
    }
}
