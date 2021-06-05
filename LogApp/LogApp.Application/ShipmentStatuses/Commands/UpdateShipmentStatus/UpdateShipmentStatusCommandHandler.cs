using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Commands.UpdateShipmentStatus
{
    public class UpdateShipmentStatusCommandHandler : IRequestHandler<UpdateShipmentStatusCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateShipmentStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateShipmentStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShipmentStatuses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ShipmentStatus), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
