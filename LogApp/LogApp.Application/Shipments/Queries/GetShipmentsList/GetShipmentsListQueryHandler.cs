using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Shipments.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Queries.GetShipmentsList
{
    public class GetShipmentsListQueryHandler : IRequestHandler<GetShipmentsListQuery, List<ShipmentViewModel>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetShipmentsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ShipmentViewModel>> Handle(GetShipmentsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Shipments
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .ThenInclude(c => c.CostCenter)
                                        .Where(d => !d.IsDeleted)
                                        .ToListAsync(cancellationToken);

            var smth = _mapper.Map<List<ShipmentViewModel>>(result);

            return smth;
        }
    }
}
