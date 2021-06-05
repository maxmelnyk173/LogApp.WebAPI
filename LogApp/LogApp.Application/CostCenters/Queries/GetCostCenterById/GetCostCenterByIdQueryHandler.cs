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

        public GetCostCenterByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CostCenterViewModel> Handle(GetCostCenterByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CostCenters
                                        .Where(b => b.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(business => new CostCenterViewModel
                                        {
                                            Id = business.Id,
                                            Name = business.Name,
                                            CostCentre = business.CostCentre
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
