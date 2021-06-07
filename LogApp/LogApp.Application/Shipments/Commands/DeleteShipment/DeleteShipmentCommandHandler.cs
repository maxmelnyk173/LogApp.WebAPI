using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteShipmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Shipments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            _context.Shipments.Remove(entity);

            DeleteConnectionToOrder(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void DeleteConnectionToOrder(DeleteShipmentCommand request)
        {
            var orders = _context.Orders.Where(x => x.ShipmentId == request.Id);

            foreach (var o in orders)
            {
                o.ShipmentId = null;
                o.IsAccepted = false;
            }
        }
    }
}
