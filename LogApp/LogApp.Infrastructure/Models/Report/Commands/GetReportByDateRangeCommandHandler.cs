using LogApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Infrastructure.Models.Report.Commands
{
    public class GetReportByDateRangeCommandHandler : IRequestHandler<GetReportByDateRangeCommand, IEnumerable<ShipmentVm>>
    {
        private readonly ApplicationDbContext _context;

        public GetReportByDateRangeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipmentVm>> Handle(GetReportByDateRangeCommand request, CancellationToken cancellationToken)
        {
            var exports = await GetExports(request);

            var imports = await GetImports(request);

            var result = exports.Concat(imports);

            return result;
        }

        private async Task<List<ShipmentVm>> GetExports(GetReportByDateRangeCommand request)
        {
            var exportsList = await _context.Exports
                                        .Where(s => s.PickUpDate >= request.LastDate)
                                        .Where(l => l.DeliveryDate <= request.LastDate)
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .ThenInclude(b => b.Business)
                                        .Select(export => new ShipmentVm
                                            {
                                                CarrierName = export.Carrier.Name,
                                                TruckNumber = export.TruckNumber,
                                                TruckType = export.TruckType,
                                                Route = export.Route,
                                                Price = export.Price,
                                                PickUpDate = export.PickUpDate,
                                                DeliveryDate = export.DeliveryDate,
                                                Orders = export.Orders.Select(order => new ShipmentOrderVm
                                                    {
                                                        LotName = order.LotName,
                                                        PackingType = order.PackingType,
                                                        GoodsQuantity = order.GoodsQuantity,
                                                        Dimensions = order.Dimensions,
                                                        Weight = order.Weight,
                                                        Stackability = order.Stackability,
                                                        Business = order.Business.Name,
                                                        CostCentre = order.Business.CostCentre,
                                                        GoodsGL = order.GoodsGL,
                                                        GoodsType = order.GoodsType
                                                    }).ToList()
                                            }).ToListAsync();
            return exportsList;
        }

        private async Task<List<ShipmentVm>> GetImports(GetReportByDateRangeCommand request)
        {
            var importsList = await _context.Imports
                                        .Where(s => s.PickUpDate >= request.LastDate)
                                        .Where(l => l.DeliveryDate <= request.LastDate)
                                        .Include(c => c.Carrier)
                                        .Include(o => o.Orders)
                                        .ThenInclude(b => b.Business)
                                        .Select(export => new ShipmentVm
                                        {
                                            CarrierName = export.Carrier.Name,
                                            TruckNumber = export.TruckNumber,
                                            TruckType = export.TruckType,
                                            Route = export.Route,
                                            Price = export.Price,
                                            PickUpDate = export.PickUpDate,
                                            DeliveryDate = export.DeliveryDate,
                                            Orders = export.Orders.Select(order => new ShipmentOrderVm
                                            {
                                                LotName = order.LotName,
                                                PackingType = order.PackingType,
                                                GoodsQuantity = order.GoodsQuantity,
                                                Dimensions = order.Dimensions,
                                                Weight = order.Weight,
                                                Stackability = order.Stackability,
                                                Business = order.Business.Name,
                                                CostCentre = order.Business.CostCentre,
                                                GoodsGL = order.GoodsGL,
                                                GoodsType = order.GoodsType
                                            }).ToList()
                                        }).ToListAsync();
            return importsList;
        }
    }
}
