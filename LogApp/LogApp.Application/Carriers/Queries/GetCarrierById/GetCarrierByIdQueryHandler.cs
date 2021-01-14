using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Queries.GetCarrierById
{
    public class GetCarrierByIdQueryHandler : IRequestHandler<GetCarrierByIdQuery, CarrierVm>
    {
        private readonly IApplicationDbContext _context;

        public GetCarrierByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CarrierVm> Handle(GetCarrierByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Carriers
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(carrier => new CarrierVm
                                        {
                                            Id = carrier.Id,
                                            Name = carrier.Name
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
