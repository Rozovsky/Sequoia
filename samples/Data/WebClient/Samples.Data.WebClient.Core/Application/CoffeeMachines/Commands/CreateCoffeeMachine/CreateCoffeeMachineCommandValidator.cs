﻿using FluentValidation;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommandValidator : AbstractValidator<CreateCoffeeMachineCommand>
    {
        public CreateCoffeeMachineCommandValidator()
        {
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
