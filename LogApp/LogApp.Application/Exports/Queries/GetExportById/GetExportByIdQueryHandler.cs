using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Queries.GetExportById
{
    public class GetExportByIdQueryHandler : IRequestHandler<GetExportByIdQuery, ExportVm>
    {
        private readonly IApplicationDbContext _context;

        public GetExportByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExportVm> Handle(GetExportByIdQuery request, CancellationToken cancellationToken)
        {
            var export = await _context.Exports
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .Select(export => new ExportVm
                                        {
                                            Id = export.Id,
                                            TruckNumber = export.TruckNumber,
                                            CarrierId = export.CarrierId,
                                            CarrierName = export.Carrier.Name,
                                            DriverDetails = export.DriverDetails,
                                            TruckType = export.TruckType,
                                            Price = export.Price,
                                            PickUpDate = export.PickUpDate,
                                            DeliveryDate = export.DeliveryDate,
                                            LogisticsNotes = export.LogisticsNotes,
                                            Orders = export.Orders.Select(o => new OrderVm
                                            {
                                                Id = o.Id,
                                                LotName = o.LotName,
                                                ExportId = o.ExportId
                                            }).ToList(),
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);

            return export;
        }
    }
}
