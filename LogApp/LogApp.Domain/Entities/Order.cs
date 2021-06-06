using LogApp.Domain.Common;
using LogApp.Domain.Enums;
using System;

namespace LogApp.Domain.Entities
{
    public class Order : AuditEntity
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public OrderType OrderType { get; set; }

        public PackingType PackingType { get; set; }

        public int GoodsQuantity { get; set; }

        public string Dimensions { get; set; }

        public int Weight { get; set; }

        public Stackability Stackability { get; set; }

        public string Route { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int GoodsGL { get; set; }

        public string GoodsType { get; set; }

        public string Notes { get; set; }

        public bool IsAccepted { get; set; }

        public CostCenter CostCenter { get; set; }

        public Shipment Shipment { get; set; }
    }
}
