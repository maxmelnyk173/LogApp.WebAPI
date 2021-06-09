using AutoMapper;
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

        private readonly IMapper _mapper;

        public UpdateShipmentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Shipments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            _mapper.Map(request.Shipment, entity);

            await UpdateConnectionsToOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task UpdateConnectionsToOrders(UpdateShipmentCommand request)
        {
            var orders = _context.Orders.Where(x => x.ShipmentId == request.Id);

            foreach (var o in orders)
            {
                o.ShipmentId = null;
                o.IsAccepted = false;
            }

            foreach (var o in request.Shipment.Orders)
            {
                var order = await _context.Orders.FindAsync(o);
                order.ShipmentId = request.Id;
                order.IsAccepted = true;
            }
        }
    }
}
