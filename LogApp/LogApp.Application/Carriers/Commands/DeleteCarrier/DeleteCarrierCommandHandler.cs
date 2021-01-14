using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Commands.DeleteCarrier
{
    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCarrierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCarrierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Carriers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carrier), request.Id);
            }

            _context.Carriers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
