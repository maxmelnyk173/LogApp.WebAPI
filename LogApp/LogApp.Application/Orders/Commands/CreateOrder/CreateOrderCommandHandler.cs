using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order()
            {
                Id = Guid.NewGuid(),
                LotName = request.LotName,
                OrderType = request.OrderType,
                PackingType = request.PackingType,
                GoodsQuantity = request.GoodsQuantity,
                Dimensions = request.Dimensions,
                Weight = request.Weight,
                Stackability = request.Stackability,
                Route = request.Route,
                PickUpDate = request.PickUpDate,
                DeliveryDate = request.DeliveryDate,
                CostCenter = request.CostCenter,
                GoodsGL = request.GoodsGL,
                GoodsType = request.GoodsType,
                Notes = request.Notes
            };

            _context.Orders.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
