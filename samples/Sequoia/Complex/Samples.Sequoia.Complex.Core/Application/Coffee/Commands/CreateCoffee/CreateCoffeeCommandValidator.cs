using FluentValidation;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.CreateCoffee
{
    public class CreateCoffeeCommandValidator : AbstractValidator<CreateCoffeeCommand>
    {
        public CreateCoffeeCommandValidator()
        {
            RuleFor(v => v.Dto.Name)
                .NotEmpty()
                    .WithMessage("Name must be set");
        }
    }
}
