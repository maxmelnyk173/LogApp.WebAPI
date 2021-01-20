using FluentValidation;
using LogApp.Application.Businesses.Commands.UpdateBusiness;

namespace LogApp.Application.Businesses.Validators
{
    public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
    {
        public UpdateBusinessCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
            RuleFor(c => c.CostCentre).NotNull().NotEmpty();
        }
    }
}
