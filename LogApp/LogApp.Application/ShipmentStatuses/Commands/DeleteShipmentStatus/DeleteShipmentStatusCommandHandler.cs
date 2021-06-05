using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Commands.DeleteShipmentStatus
{
    public class DeleteShipmentStatusCommandHandler : IRequestHandler<DeleteShipmentStatusCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteShipmentStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShipmentStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShipmentStatuses.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(ShipmentStatus), request.Id);
            }

            _context.ShipmentStatuses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
