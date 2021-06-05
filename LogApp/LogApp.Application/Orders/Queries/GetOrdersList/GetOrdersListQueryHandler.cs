using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrdersListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                .Include(b => b.Business)
                                .Where(d => !d.IsDeleted)
                                .Select(business => new OrderViewModel
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
                                }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
