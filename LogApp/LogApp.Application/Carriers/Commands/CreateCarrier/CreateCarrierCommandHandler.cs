using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Carriers.Commands.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarrierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCarrierCommand request, CancellationToken cancellationToken)
        {
            var entity = new Carrier()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            _context.Carriers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
