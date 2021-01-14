using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVm>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                        .Include(o => o.Business)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(business => new OrderVm
                                        {
                                            Id = business.Id,
                                            LotName = business.LotName,
                                            PackingType = business.PackingType,
                                            GoodsQuantity = business.GoodsQuantity,
                                            Dimensions = business.Dimensions,
                                            Weight = business.Weight,
                                            Stackability = business.Stackability,
                                            Route = business.Route,
                                            PickUpDate = business.PickUpDate,
                                            DeliveryDate = business.DeliveryDate,
                                            GoodsGL = business.GoodsGL,
                                            GoodsType = business.GoodsType,
                                            Notes = business.Notes,
                                            BusinessName = business.Business.Name,
                                            CostCentre = business.Business.CostCentre
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
