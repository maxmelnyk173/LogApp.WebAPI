using FluentValidation;
using LogApp.Application.Carriers.Commands.CreateCarrier;

namespace LogApp.Application.Carriers.Validators
{
    public class CreateCarrierCommandValidator : AbstractValidator<CreateCarrierCommand>
    {
        public CreateCarrierCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
        }
    }
}
