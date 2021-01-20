using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Infrastructure.Models.Report
{
    public class ShipmentVm
    {
        public ShipmentVm()
        {
            Orders = new List<ShipmentOrderVm>();
        }

        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public string CarrierName { get; set; }

        public string TruckNumber { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public ICollection<ShipmentOrderVm> Orders { get; set; }
    }
}
