using LogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<CostCenter> CostCenters { get; set; }

        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ShipmentStatus> ShipmentStatuses { get; set; }

        public DbSet<WarehouseStatus> WarehouseStatuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
