using FluentValidation;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.UpdateCoffee
{
    public class UpdateCoffeeCommandValidator : AbstractValidator<UpdateCoffeeCommand>
    {
        public UpdateCoffeeCommandValidator()
        {
            RuleFor(v => v.Dto.Name)
                .NotEmpty()
                    .WithMessage("Name must be set");
        }
    }
}
