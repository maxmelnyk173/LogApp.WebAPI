using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Commands.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCarrierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Carriers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carriers), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
