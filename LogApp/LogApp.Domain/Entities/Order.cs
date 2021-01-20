using LogApp.Domain.Common;
using LogApp.Domain.Enums;
using System;

namespace LogApp.Domain.Entities
{
    public class Order : AuditEntity
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public PackingType PackingType { get; set; }

        public int GoodsQuantity { get; set; }

        public string Dimensions { get; set; }

        public int Weight { get; set; }

        public Stackability Stackability { get; set; }

        public string Route { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Guid BusinessId { get; set; }

        public Business Business { get; set; }

        public int GoodsGL { get; set; }

        public string GoodsType { get; set; }

        public string Notes { get; set; }

        public bool IsCompleted { get; set; }

        public Guid? ExportId { get; set; }

        public Guid? ImportId { get; set; }

        public Export Export { get; set; }

        public Import Import { get; set; }
    }
}
