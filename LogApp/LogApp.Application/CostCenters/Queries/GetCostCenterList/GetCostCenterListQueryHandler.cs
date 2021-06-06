using AutoMapper;
using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Queries.GetCostCenterList
{
    public class GetCostCenterListQueryHandler : IRequestHandler<GetCostCenterListQuery, List<CostCenterViewModel>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetCostCenterListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CostCenterViewModel>> Handle(GetCostCenterListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CostCenters
                                       .Where(d => !d.IsDeleted)
                                       .ToListAsync(cancellationToken);

            return _mapper.Map<List<CostCenterViewModel>>(result);
        }
    }
}
