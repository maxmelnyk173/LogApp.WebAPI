using FluentValidation;
using LogApp.Application.Orders.Commands.UpdateOrder;

namespace LogApp.Application.Orders.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(n => n.Order.LotName).NotNull().NotEmpty();
            RuleFor(p => p.Order.PackingType).IsInEnum();
            RuleFor(g => g.Order.GoodsQuantity).GreaterThan(0);
            RuleFor(d => d.Order.Dimensions).NotNull().NotEmpty();
            RuleFor(w => w.Order.Weight).GreaterThan(0);
            RuleFor(s => s.Order.Stackability).IsInEnum();
            RuleFor(r => r.Order.Route).NotNull().NotEmpty();
            RuleFor(p => p.Order.PickUpDate).NotNull();
            RuleFor(d => d.Order.DeliveryDate).NotNull();
            RuleFor(gl => gl.Order.GoodsGL).NotEmpty().GreaterThan(0);
            RuleFor(t => t.Order.GoodsType).NotNull().NotEmpty();
        }
    }
}

