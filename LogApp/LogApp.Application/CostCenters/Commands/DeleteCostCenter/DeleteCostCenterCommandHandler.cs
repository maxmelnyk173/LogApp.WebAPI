using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Commands.DeleteCostCenter
{
    public class DeleteCostCenterCommandHandler : IRequestHandler<DeleteCostCenterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCostCenterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCostCenterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CostCenters.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carrier), request.Id);
            }

            _context.CostCenters.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
