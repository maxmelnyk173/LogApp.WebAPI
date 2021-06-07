using AutoMapper;
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

        private readonly IMapper _mapper;

        public GetShipmentStatusesListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ShipmentStatusViewModel>> Handle(GetShipmentStatusesListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ShipmentStatuses
                                       .Where(s => !s.IsDeleted)
                                       .ToListAsync(cancellationToken);

            return _mapper.Map<List<ShipmentStatusViewModel>>(result);
        }
    }
}
