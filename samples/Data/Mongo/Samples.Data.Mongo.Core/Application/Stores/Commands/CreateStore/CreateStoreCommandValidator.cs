using FluentValidation;

namespace Samples.Data.Mongo.Core.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
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
