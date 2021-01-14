using FluentValidation;
using LogApp.Application.Orders.Commands.CreateOrder;

namespace LogApp.Application.Orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(n => n.LotName).NotNull().NotEmpty().WithMessage("Lot name should not be empty");
            RuleFor(p => p.PackingType).IsInEnum();
            RuleFor(g => g.GoodsQuantity).GreaterThan(0).WithMessage("Quantity should be greater than 0");
            RuleFor(d => d.Dimensions).NotNull().NotEmpty().WithMessage("Dimensions should not be empty");
            RuleFor(w => w.Weight).GreaterThan(0).WithMessage("Weight should be greater than 0");
            RuleFor(s => s.Stackability).IsInEnum();
            RuleFor(r => r.Route).NotNull().NotEmpty().WithMessage("Route should not be empty");
            RuleFor(p => p.PickUpDate).NotNull();
            RuleFor(d => d.DeliveryDate).NotNull();
            RuleFor(b => b.BusinessId).NotNull().NotEmpty().WithMessage("Business should be assigned");
            RuleFor(gl => gl.GoodsGL).NotEmpty().GreaterThan(0).WithMessage("Gl should not be empty");
            RuleFor(t => t.GoodsType).NotNull().NotEmpty().WithMessage("Please indicate the type of goods");
        }
    }
}
