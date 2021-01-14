using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Commands.UpdateExport
{
    public class UpdateExportCommandHandler : IRequestHandler<UpdateExportCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateExportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Exports.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Export), request.Id);
            }

            entity.CarrierId = request.CarrierId;
            entity.TruckNumber = request.TruckNumber;
            entity.DriverDetails = request.DriverDetails;
            entity.TruckType = request.TruckType;
            entity.Price = request.Price;
            entity.PickUpDate = request.PickUpDate;
            entity.DeliveryDate = request.DeliveryDate;
            entity.LogisticsNotes = request.LogisticsNotes;

            CleanOrders(request);

            AssignOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CleanOrders(UpdateExportCommand request)
        {
            var result = _context.Orders.Where(o => o.ExportId == request.Id).ToList();

            foreach (var item in result)
            {
                item.ExportId = null;
            }
        }

        private void AssignOrders(UpdateExportCommand request)
        {
            if ((request.Orders).Count != 0)
            {
                foreach (var item in request.Orders)
                {
                    var result = _context.Orders.Find(item.Id);

                    result.ExportId = request.Id;
                }
            }
        }
    }
}
