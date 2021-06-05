using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusesList
{
    public class GetShipmentStatusesListQueryHandler : IRequestHandler<GetShipmentStatusesListQuery, List<ShipmentStatusViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetShipmentStatusesListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShipmentStatusViewModel>> Handle(GetShipmentStatusesListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ShipmentStatuses
                                        .Where(d => !d.IsDeleted)
                                        .Select(carrier => new ShipmentStatusViewModel
                                        {
                                            Id = carrier.Id,
                                            Name = carrier.Name
                                        }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
