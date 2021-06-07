using AutoMapper;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Commands.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public UpdateCarrierCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Carriers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carrier), request.Id);
            }

            _mapper.Map(request.Carrier, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
