using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateShipmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Shipment()
            {
                Id = Guid.NewGuid(),
                Carrier = request.Carrier,
                TruckNumber = request.TruckNumber,
                DriverDetails = request.DriverDetails,
                TruckType = request.TruckType,
                Route = request.Route,
                Price = request.Price,
                PickUpDate = request.PickUpDate,
                DeliveryDate = request.DeliveryDate,
                LogisticsNotes = request.LogisticsNotes
            };

            _context.Shipments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
