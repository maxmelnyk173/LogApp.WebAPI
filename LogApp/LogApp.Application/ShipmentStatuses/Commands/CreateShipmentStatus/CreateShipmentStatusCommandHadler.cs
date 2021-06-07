using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus
{
    public class CreateShipmentStatusCommandHadler : IRequestHandler<CreateShipmentStatusCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CreateShipmentStatusCommandHadler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateShipmentStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ShipmentStatus>(request);

            _context.ShipmentStatuses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
