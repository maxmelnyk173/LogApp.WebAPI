using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Commands.UpdateCostCenter
{
    public class UpdateCostCenterCommandHandler : IRequestHandler<UpdateCostCenterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCostCenterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CostCenters.FindAsync(request.Id);

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
