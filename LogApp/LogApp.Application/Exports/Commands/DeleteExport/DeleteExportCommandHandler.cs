using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Commands.DeleteExport
{
    public class DeleteExportCommandHandler : IRequestHandler<DeleteExportCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Exports.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Export), request.Id);
            }

            _context.Exports.Remove(entity);

            CleanOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CleanOrders(DeleteExportCommand request)
        {
            var result = _context.Orders.Where(o => o.ExportId == request.Id).ToList();

            foreach (var item in result)
            {
                item.ExportId = null;
            }
        }
    }
}
