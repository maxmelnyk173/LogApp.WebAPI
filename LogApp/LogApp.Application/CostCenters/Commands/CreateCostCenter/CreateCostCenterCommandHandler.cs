using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Commands.CreateCostCenter
{
    public class CreateCostCenterCommandHandler : IRequestHandler<CreateCostCenterCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCostCenterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var entity = new CostCenter()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CostCentre = request.CostCentre
            };

            _context.CostCenters.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
