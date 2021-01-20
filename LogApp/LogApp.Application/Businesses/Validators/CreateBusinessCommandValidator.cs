using FluentValidation;
using LogApp.Application.Businesses.Commands.CreateBusiness;

namespace LogApp.Application.Businesses.Validators
{
    public class CreateBusinessCommandValidator : AbstractValidator<CreateBusinessCommand>
    {
        public CreateBusinessCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
            RuleFor(c => c.CostCentre).NotNull().NotEmpty();
        }
    }
}
