using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                        .Include(o => o.CostCenter)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(order => new OrderViewModel
                                        {
                                            Id = order.Id,
                                            LotName = order.LotName,
                                            OrderType = order.OrderType,
                                            PackingType = order.PackingType,
                                            GoodsQuantity = order.GoodsQuantity,
                                            Dimensions = order.Dimensions,
                                            Weight = order.Weight,
                                            Stackability = order.Stackability,
                                            Route = order.Route,
                                            PickUpDate = order.PickUpDate,
                                            DeliveryDate = order.DeliveryDate,
                                            GoodsGL = order.GoodsGL,
                                            GoodsType = order.GoodsType,
                                            Notes = order.Notes,
                                            CostCenter = order.CostCenter,
                                            IsAccepted = order.IsAccepted,
                                            Shipment = order.Shipment
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
