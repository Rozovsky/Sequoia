using FluentValidation;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommandValidator : AbstractValidator<UpdateCoffeeMachineCommand>
    {
        public UpdateCoffeeMachineCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");

            RuleFor(v => v.Dto.StoreId)
                .GreaterThan(0)
                    .WithMessage("StoreId must be set");

            RuleFor(v => v.Dto.Brand)
                .MaximumLength(64)
                    .WithMessage("Brand maximum length is 64")
                .NotEmpty()
                    .WithMessage("Brand must be set");

            RuleFor(v => v.Dto.Model)
                .MaximumLength(64)
                    .WithMessage("Model maximum length is 64")
                .NotEmpty()
                    .WithMessage("Model must be set");
        }
    }
}
