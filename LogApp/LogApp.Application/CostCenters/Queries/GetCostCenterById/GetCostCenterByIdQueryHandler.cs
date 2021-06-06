using AutoMapper;
using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Queries.GetCostCenterById
{
    public class GetCostCenterByIdQueryHandler : IRequestHandler<GetCostCenterByIdQuery, CostCenterViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetCostCenterByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CostCenterViewModel> Handle(GetCostCenterByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CostCenters
                                       .Where(b => b.Id == request.Id)
                                       .Where(d => !d.IsDeleted)
                                       .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<CostCenterViewModel>(result);
        }
    }
}
