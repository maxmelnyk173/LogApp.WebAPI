using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Imports.Commands.CreateImport
{
    public class CreateImportCommandHandler : IRequestHandler<CreateImportCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateImportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateImportCommand request, CancellationToken cancellationToken)
        {
            var entity = new Import()
            {
                Id = Guid.NewGuid(),
                CarrierId = request.CarrierId,
                TruckNumber = request.TruckNumber,
                DriverDetails = request.DriverDetails,
                TruckType = request.TruckType,
                Price = request.Price,
                PickUpDate = request.PickUpDate,
                DeliveryDate = request.DeliveryDate,
                LogisticsNotes = request.LogisticsNotes
            };

            _context.Imports.Add(entity);

            AssignOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        private void AssignOrders(CreateImportCommand request)
        {
            if ((request.Orders).Count != 0)
            {
                foreach (var item in request.Orders)
                {
                    var result = _context.Orders.Find(item.Id);
                    result.ImportId = request.Id;
                }
            }
        }
    }
}
