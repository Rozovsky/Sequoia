using FluentValidation;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommandValidator : AbstractValidator<DeleteCoffeeMachineCommand>
    {
        public DeleteCoffeeMachineCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");
        }
    }
}
