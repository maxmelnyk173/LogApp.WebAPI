using LogApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Imports.Queries.GetImportsByDate
{
    public class GetImportsByDateQueryHandler : IRequestHandler<GetImportsByDateQuery, List<ImportVm>>
    {
        private readonly IApplicationDbContext _context;

        public GetImportsByDateQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ImportVm>> Handle(GetImportsByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Imports
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .Where(d => d.PickUpDate == request.Date)
                                        .Where(i => !i.IsDeleted)
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
                                        .ToListAsync(cancellationToken);

            return result;
        }
    }
}
