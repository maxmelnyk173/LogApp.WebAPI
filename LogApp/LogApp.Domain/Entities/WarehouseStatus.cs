using LogApp.Domain.Common;
using LogApp.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class WarehouseStatus : AuditEntity
    {
        public Guid Id { get; set; }

        public CustomsStatus CustomsStatus { get; set; }

        public string CustomsNotes { get; set; }

        public Guid ShipmentStatusId { get; set; }

        public virtual ShipmentStatus ShipmentStatus { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime UnloadingReceiving { get; set; }

        public DateTime UnloadingGP { get; set; }

        public DateTime TruckReleasedTime { get; set; }

        public string InventoryOrSecurityNotes { get; set; }

        public Guid? ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}
