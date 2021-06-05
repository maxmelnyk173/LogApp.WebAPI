using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Queries.GetShipmentsList
{
    public class GetImportsListQueryHandler : IRequestHandler<GetShipmentsListQuery, List<ShipmentViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetImportsListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShipmentViewModel>> Handle(GetShipmentsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Shipments
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(d => !d.IsDeleted)
                                        .Select(import => new ShipmentViewModel
                                        {
                                            Id = import.Id,
                                            TruckNumber = import.TruckNumber,
                                            CarrierName = import.Carrier.Name,
                                            DriverDetails = import.DriverDetails,
                                            TruckType = import.TruckType,
                                            Route = import.Route,
                                            Price = import.Price,
                                            PickUpDate = import.PickUpDate,
                                            DeliveryDate = import.DeliveryDate,
                                            LogisticsNotes = import.LogisticsNotes,
                                        })
                                        .ToListAsync(cancellationToken);

            return result;
        }
    }
}
