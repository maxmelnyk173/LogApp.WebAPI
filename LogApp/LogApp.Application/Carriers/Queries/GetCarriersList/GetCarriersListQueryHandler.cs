using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Queries.GetCarriersList
{
    public class GetCarriersListQueryHandler : IRequestHandler<GetCarriersListQuery, List<CarrierViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetCarriersListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarrierViewModel>> Handle(GetCarriersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Carriers
                                        .Where(d => !d.IsDeleted)
                                        .Select(carrier => new CarrierViewModel
                                        {
                                            Id = carrier.Id,
                                            Name = carrier.Name
                                        }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
