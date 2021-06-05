using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusById
{
    public class GetShipmentStatusByIdQueryHandler : IRequestHandler<GetShipmentStatusByIdQuery, ShipmentStatusViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetShipmentStatusByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShipmentStatusViewModel> Handle(GetShipmentStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ShipmentStatuses
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(shipment => new ShipmentStatusViewModel
                                        {
                                            Id = shipment.Id,
                                            Name = shipment.Name
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
