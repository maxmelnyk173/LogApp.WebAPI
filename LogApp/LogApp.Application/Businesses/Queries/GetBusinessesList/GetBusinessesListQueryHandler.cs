using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Queries.GetBusinessesList
{
    public class GetBusinessesListQueryHandler : IRequestHandler<GetBusinessesListQuery, List<BusinessVm>>
    {
        private readonly IApplicationDbContext _context;

        public GetBusinessesListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BusinessVm>> Handle(GetBusinessesListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Businesses
                                       .Where(d => !d.IsDeleted)
                                       .Select(business => new BusinessVm
                                       {
                                           Id = business.Id,
                                           Name = business.Name,
                                           CostCentre = business.CostCentre
                                       }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
