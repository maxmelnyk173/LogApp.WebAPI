using LogApp.Application.Businesses.Commands.DeleteBusiness;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Commands.DeleteBusinesses
{
    public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBusinessCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Businesses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carrier), request.Id);
            }

            _context.Businesses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
