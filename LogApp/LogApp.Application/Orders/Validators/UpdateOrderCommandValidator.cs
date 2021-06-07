using FluentValidation;
using LogApp.Application.Orders.Commands.UpdateOrder;

namespace LogApp.Application.Orders.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(n => n.Order.LotName).NotNull().NotEmpty().WithMessage("Lot name should not be empty");
            RuleFor(p => p.Order.PackingType).IsInEnum();
            RuleFor(g => g.Order.GoodsQuantity).GreaterThan(0).WithMessage("Quantity should be greater than 0");
            RuleFor(d => d.Order.Dimensions).NotNull().NotEmpty().WithMessage("Dimensions should not be empty");
            RuleFor(w => w.Order.Weight).GreaterThan(0).WithMessage("Weight should be greater than 0");
            RuleFor(s => s.Order.Stackability).IsInEnum();
            RuleFor(r => r.Order.Route).NotNull().NotEmpty().WithMessage("Route should not be empty");
            RuleFor(p => p.Order.PickUpDate).NotNull();
            RuleFor(d => d.Order.DeliveryDate).NotNull();
            RuleFor(gl => gl.Order.GoodsGL).NotEmpty().GreaterThan(0).WithMessage("Gl should not be empty");
            RuleFor(t => t.Order.GoodsType).NotNull().NotEmpty().WithMessage("Please indicate the type of goods");
        }
    }
}

