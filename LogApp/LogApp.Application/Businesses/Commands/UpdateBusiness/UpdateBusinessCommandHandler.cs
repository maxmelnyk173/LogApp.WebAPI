using LogApp.Application.Businesses.Commands.UpdateBusiness;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Commands.UpdateBusinesses
{
    public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBusinessCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Businesses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carriers), request.Id);
            }

            entity.Name = request.Name;
            entity.CostCentre = request.CostCentre;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
