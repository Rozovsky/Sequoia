using FluentValidation;

namespace Samples.Common.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .WithMessage("Id must be set");
    }
}