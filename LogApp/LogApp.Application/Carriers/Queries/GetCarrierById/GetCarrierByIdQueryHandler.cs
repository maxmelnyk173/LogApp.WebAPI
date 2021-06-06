using AutoMapper;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Queries.GetCarrierById
{
    public class GetCarrierByIdQueryHandler : IRequestHandler<GetCarrierByIdQuery, CarrierViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetCarrierByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarrierViewModel> Handle(GetCarrierByIdQuery request, CancellationToken cancellationToken)
        {
            var carrier = await _context.Carriers
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .FirstOrDefaultAsync(cancellationToken);
            if(carrier == null)
            {
                throw new NotFoundException(nameof(Carrier), request.Id);
            }

            return _mapper.Map<CarrierViewModel>(carrier);
        }
    }
}
