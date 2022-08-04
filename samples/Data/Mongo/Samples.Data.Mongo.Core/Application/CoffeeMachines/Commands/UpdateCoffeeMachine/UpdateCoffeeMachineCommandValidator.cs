using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommandValidator : AbstractValidator<UpdateCoffeeMachineCommand>
    {
        public UpdateCoffeeMachineCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                    .WithMessage("Id must be set");

            RuleFor(v => v.Dto.StoreId)
                .NotEmpty()
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
