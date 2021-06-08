using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Shipments.Commands
{
    public class ShipmentCommandViewModel
    {
        public Guid CarrierId { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public List<Guid> Orders { get; set; }
    }
}
