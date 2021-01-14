using LogApp.Domain.Common;
using LogApp.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class Import : AuditEntity
    {
        public Import()
        {
            Orders = new HashSet<Order>();
        }
        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime UnloadingReceiving { get; set; }

        public DateTime UnloadingGP { get; set; }

        public ImportStatus ImportStatus { get; set; }

        public CustomsStatus CustomsStatus { get; set; }

        public DateTime TruckReleasedTime { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public string InventoryOrSecurityNotes { get; set; }

        public string CustomsNotes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
