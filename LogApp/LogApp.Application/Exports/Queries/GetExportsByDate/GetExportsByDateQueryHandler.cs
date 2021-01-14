using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Queries.GetExportsByDate
{
    public class GetExportsByDateQueryHandler : IRequestHandler<GetExportsByDateQuery, List<ExportVm>>
    {
        private readonly IApplicationDbContext _context;

        public GetExportsByDateQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExportVm>> Handle(GetExportsByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Exports
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(d => d.PickUpDate == request.Date)
                                        .Where(i => !i.IsDeleted)
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
                                        .ToListAsync(cancellationToken);

            return result;
        }
    }
}
