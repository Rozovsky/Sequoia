using FluentValidation;

namespace Samples.Common.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(v => v.Dto.Name)
            .MaximumLength(64)
            .WithMessage("Name maximum length is 64")
            .NotEmpty()
            .WithMessage("Name must be set");
    }
}