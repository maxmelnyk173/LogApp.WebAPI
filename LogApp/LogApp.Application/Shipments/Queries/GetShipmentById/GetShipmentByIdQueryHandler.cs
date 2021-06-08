using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Shipments.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetShipmentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShipmentViewModel> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Shipments
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .ThenInclude(c => c.CostCenter)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<ShipmentViewModel>(result);
        }
    }
}
