using FluentValidation;
using LogApp.Application.Orders.Commands.CreateOrder;

namespace LogApp.Application.Orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(n => n.LotName).NotNull().NotEmpty();
            RuleFor(p => p.PackingType).IsInEnum();
            RuleFor(g => g.GoodsQuantity).GreaterThan(0);
            RuleFor(d => d.Dimensions).NotNull().NotEmpty();
            RuleFor(w => w.Weight).GreaterThan(0);
            RuleFor(s => s.Stackability).IsInEnum();
            RuleFor(r => r.Route).NotNull().NotEmpty();
            RuleFor(p => p.PickUpDate).NotNull();
            RuleFor(d => d.DeliveryDate).NotNull();
            RuleFor(gl => gl.GoodsGL).NotEmpty().GreaterThan(0);
            RuleFor(t => t.GoodsType).NotNull().NotEmpty();
        }
    }
}
