using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Queries.GetBusinessById
{
    public class GetBusinessByIdQueryHandler : IRequestHandler<GetBusinessByIdQuery, BusinessVm>
    {
        private readonly IApplicationDbContext _context;

        public GetBusinessByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BusinessVm> Handle(GetBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Businesses
                                        .Where(b => b.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(business => new BusinessVm
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
