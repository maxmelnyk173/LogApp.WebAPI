using AutoMapper;
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

        private readonly IMapper _mapper;

        public CreateCostCenterCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CostCenter>(request);

            _context.CostCenters.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
