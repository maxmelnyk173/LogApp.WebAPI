using FluentValidation;
using LogApp.Application.CostCenters.Commands.UpdateCostCenter;

namespace LogApp.Application.CostCenters.Validators
{
    public class UpdateCostCenterCommandValidator : AbstractValidator<UpdateCostCenterCommand>
    {
        public UpdateCostCenterCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
            RuleFor(c => c.CostCentre).NotNull().NotEmpty();
        }
    }
}
