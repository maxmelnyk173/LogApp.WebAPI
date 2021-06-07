using AutoMapper;
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

        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            await AddConnectionToOrder(request);

            var entity = _mapper.Map<Shipment>(request);

            _context.Shipments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        private async Task AddConnectionToOrder(CreateShipmentCommand request)
        {
            foreach (var o in request.Orders)
            {
                var order = await _context.Orders.FindAsync(o);
                order.ShipmentId = request.Id;
                order.IsAccepted = true;
            }
        }
    }
}
