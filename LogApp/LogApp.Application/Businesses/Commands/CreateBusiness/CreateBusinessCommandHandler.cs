using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Businesses.Commands.CreateBusiness
{
    public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateBusinessCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
        {
            var entity = new CostCenter()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CostCentre = request.CostCentre
            };

            _context.Businesses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
