using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Commands.UpdateShipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateShipmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Shipments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            entity.TruckNumber = request.TruckNumber;
            entity.DriverDetails = request.DriverDetails;
            entity.TruckType = request.TruckType;
            entity.Route = request.Route;
            entity.Price = request.Price;
            entity.PickUpDate = request.PickUpDate;
            entity.DeliveryDate = request.DeliveryDate;
            entity.LogisticsNotes = request.LogisticsNotes;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
