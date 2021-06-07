using AutoMapper;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.CostCenters.Commands.UpdateCostCenter
{
    public class UpdateCostCenterCommandHandler : IRequestHandler<UpdateCostCenterCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public UpdateCostCenterCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CostCenters.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Carriers), request.Id);
            }

            _mapper.Map(request.CostCenter, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
