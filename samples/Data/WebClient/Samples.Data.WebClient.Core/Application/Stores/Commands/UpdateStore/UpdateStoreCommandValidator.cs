using FluentValidation;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                    .WithMessage("Id must be set");

            RuleFor(v => v.Dto.Type)
                .IsInEnum()
                    .WithMessage("Invalid Type");

            RuleFor(v => v.Dto.Name)
                .MaximumLength(64)
                    .WithMessage("Name maximum length is 64")
                .NotEmpty()
                    .WithMessage("Name must be set");

            RuleFor(v => v.Dto.Address)
                .MaximumLength(128)
                    .WithMessage("Address maximum length is 128")
                .NotEmpty()
                    .WithMessage("Address must be set");
        }
    }
}
