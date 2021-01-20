using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Commands.CreateExport
{
    public class CreateExportCommandHandler : IRequestHandler<CreateExportCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateExportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateExportCommand request, CancellationToken cancellationToken)
        {
            var entity = new Export()
            {
                Id = Guid.NewGuid(),
                CarrierId = request.CarrierId,
                TruckNumber = request.TruckNumber,
                DriverDetails = request.DriverDetails,
                TruckType = request.TruckType,
                Route = request.Route,
                Price = request.Price,
                PickUpDate = request.PickUpDate,
                DeliveryDate = request.DeliveryDate,
                LogisticsNotes = request.LogisticsNotes
            };

            _context.Exports.Add(entity);

            AssignOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        private void AssignOrders(CreateExportCommand request)
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
