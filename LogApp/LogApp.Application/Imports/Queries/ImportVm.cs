using System;
using System.Collections.Generic;

namespace LogApp.Application.Imports.Queries
{
    public class ImportVm
    {
        public ImportVm()
        {
            Orders = new List<ImportOrderVm>();
        }

        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public string CarrierName { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public ICollection<ImportOrderVm> Orders { get; set; }
    }
}
