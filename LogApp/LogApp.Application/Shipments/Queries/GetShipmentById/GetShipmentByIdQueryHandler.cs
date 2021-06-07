using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetShipmentByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShipmentViewModel> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var export = await _context.Shipments
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(c => c.Id == request.Id)
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
                                            LogisticsNotes = import.LogisticsNotes
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return export;
        }
    }
}
