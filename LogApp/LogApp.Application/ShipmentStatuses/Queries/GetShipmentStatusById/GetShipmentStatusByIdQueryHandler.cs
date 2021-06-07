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

namespace LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusById
{
    public class GetShipmentStatusByIdQueryHandler : IRequestHandler<GetShipmentStatusByIdQuery, ShipmentStatusViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetShipmentStatusByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShipmentStatusViewModel> Handle(GetShipmentStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ShipmentStatuses
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<ShipmentStatusViewModel>(result);
        }
    }
}
