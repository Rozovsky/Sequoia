﻿using FluentValidation;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommandValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");
        }
    }
}
