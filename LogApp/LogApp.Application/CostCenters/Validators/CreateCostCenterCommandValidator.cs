using FluentValidation;
using LogApp.Application.CostCenters.Commands.CreateCostCenter;

namespace LogApp.Application.CostCenters.Validators
{
    public class CreateCostCenterCommandValidator : AbstractValidator<CreateCostCenterCommand>
    {
        public CreateCostCenterCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
            RuleFor(c => c.CostCentre).NotNull().NotEmpty();
        }
    }
}
