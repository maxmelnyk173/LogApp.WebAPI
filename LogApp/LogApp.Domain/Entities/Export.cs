using LogApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class Export : AuditEntity
    {
        public Export()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime LoadingTime { get; set; }

        public DateTime TruckReleasedTime { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public string InventoryOrSecurityNotes { get; set; }

        public string CustomsNotes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
