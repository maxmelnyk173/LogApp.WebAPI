using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Exports.Queries.GetExportsByDatesRange
{
    public class GetExportsByDateRangeQueryHandler : IRequestHandler<GetExportsByDateRangeQuery, List<ExportVm>>
    {
        private readonly IApplicationDbContext _context;

        public GetExportsByDateRangeQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExportVm>> Handle(GetExportsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Exports
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(s => s.PickUpDate >= request.StartDate)
                                        .Where(l => l.DeliveryDate <= request.LastDate)
                                        .Where(i => !i.IsDeleted)
                                        .Select(export => new ExportVm
                                        {
                                            Id = export.Id,
                                            TruckNumber = export.TruckNumber,
                                            CarrierId = export.CarrierId,
                                            CarrierName = export.Carrier.Name,
                                            DriverDetails = export.DriverDetails,
                                            TruckType = export.TruckType,
                                            Route = export.Route,
                                            Price = export.Price,
                                            PickUpDate = export.PickUpDate,
                                            DeliveryDate = export.DeliveryDate,
                                            LogisticsNotes = export.LogisticsNotes,
                                            Orders = export.Orders.Select(o => new ExportOrderVm
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
