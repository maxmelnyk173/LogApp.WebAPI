using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Imports.Commands.UpdateImport
{
    public class UpdateImportCommandHandler : IRequestHandler<UpdateImportCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateImportCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateImportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Imports.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Import), request.Id);
            }

            entity.CarrierId = request.CarrierId;
            entity.TruckNumber = request.TruckNumber;
            entity.DriverDetails = request.DriverDetails;
            entity.TruckType = request.TruckType;
            entity.Route = request.Route;
            entity.Price = request.Price;
            entity.PickUpDate = request.PickUpDate;
            entity.DeliveryDate = request.DeliveryDate;
            entity.LogisticsNotes = request.LogisticsNotes;

            CleanOrders(request);

            AssignOrders(request);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CleanOrders(UpdateImportCommand request)
        {
            var result = _context.Orders.Where(o => o.ImportId == request.Id).ToList();

            foreach (var item in result)
            {
                item.ImportId = null;
            }
        }

        private void AssignOrders(UpdateImportCommand request)
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
