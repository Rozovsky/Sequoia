using FluentValidation;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
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
