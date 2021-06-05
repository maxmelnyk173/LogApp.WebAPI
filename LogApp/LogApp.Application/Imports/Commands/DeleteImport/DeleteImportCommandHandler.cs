using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Imports.Commands.DeleteImport
{
    public class DeleteImportCommandHandler : IRequestHandler<DeleteImportCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteImportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteImportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Imports.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            _context.Imports.Remove(entity);

            CleanOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CleanOrders(DeleteImportCommand request)
        {
            var result = _context.Orders.Where(o => o.ImportId == request.Id).ToList();

            foreach (var item in result)
            {
                item.ImportId = null;
            }
        }
    }
}
