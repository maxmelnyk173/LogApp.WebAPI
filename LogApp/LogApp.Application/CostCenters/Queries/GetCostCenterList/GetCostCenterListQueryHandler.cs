using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Queries.GetCostCenterList
{
    public class GetCostCenterListQueryHandler : IRequestHandler<GetCostCenterListQuery, List<CostCenterViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetCostCenterListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CostCenterViewModel>> Handle(GetCostCenterListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CostCenters
                                       .Where(d => !d.IsDeleted)
                                       .Select(business => new CostCenterViewModel
                                       {
                                           Id = business.Id,
                                           Name = business.Name,
                                           CostCentre = business.CostCentre
                                       }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
