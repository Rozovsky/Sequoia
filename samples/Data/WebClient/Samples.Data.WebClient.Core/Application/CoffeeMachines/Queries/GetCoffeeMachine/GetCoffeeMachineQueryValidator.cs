﻿using FluentValidation;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine
{
    public class GetCoffeeMachineQueryValidator : AbstractValidator<GetCoffeeMachineQuery>
    {
        public GetCoffeeMachineQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");
        }
    }
}
