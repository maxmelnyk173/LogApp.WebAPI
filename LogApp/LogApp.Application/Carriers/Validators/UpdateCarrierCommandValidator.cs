using FluentValidation;
using LogApp.Application.Carriers.Commands.UpdateCarrier;

namespace LogApp.Application.Carriers.Validators
{
    public class UpdateCarrierCommandValidator : AbstractValidator<UpdateCarrierCommand>
    {
        public UpdateCarrierCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
        }
    }
}
