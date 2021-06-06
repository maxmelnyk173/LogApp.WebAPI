using AutoMapper;
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

        private readonly IMapper _mapper;
        public GetCarriersListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CarrierViewModel>> Handle(GetCarriersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Carriers
                                       .Where(d => !d.IsDeleted)
                                       .ToListAsync(cancellationToken);

            return _mapper.Map<List<CarrierViewModel>>(result);
        }
    }
}
