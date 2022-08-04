using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommandValidator : AbstractValidator<DeleteCoffeeMachineCommand>
    {
        public DeleteCoffeeMachineCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                    .WithMessage("Id must be set");
        }
    }
}
