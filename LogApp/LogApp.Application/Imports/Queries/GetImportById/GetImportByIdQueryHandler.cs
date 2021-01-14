using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Imports.Queries.GetImportById
{
    public class GetImportByIdQueryHandler : IRequestHandler<GetImportByIdQuery, ImportVm>
    {
        private readonly IApplicationDbContext _context;

        public GetImportByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ImportVm> Handle(GetImportByIdQuery request, CancellationToken cancellationToken)
        {
            var export = await _context.Imports
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(import => new ImportVm
                                        {
                                            Id = import.Id,
                                            TruckNumber = import.TruckNumber,
                                            CarrierId = import.CarrierId,
                                            CarrierName = import.Carrier.Name,
                                            DriverDetails = import.DriverDetails,
                                            TruckType = import.TruckType,
                                            Price = import.Price,
                                            PickUpDate = import.PickUpDate,
                                            DeliveryDate = import.DeliveryDate,
                                            LogisticsNotes = import.LogisticsNotes,
                                            Orders = import.Orders.Select(o => new OrderVm
                                            {
                                                Id = o.Id,
                                                LotName = o.LotName,
                                                ImportId = o.ImportId
                                            }).ToList(),
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return export;
        }
    }
}
