using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus
{
    public class CreateShipmentStatusCommandHadler : IRequestHandler<CreateShipmentStatusCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateShipmentStatusCommandHadler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateShipmentStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new ShipmentStatus()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            _context.ShipmentStatuses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
