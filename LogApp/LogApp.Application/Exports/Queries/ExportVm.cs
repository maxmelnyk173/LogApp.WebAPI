﻿using System;
using System.Collections.Generic;

namespace LogApp.Application.Exports.Queries
{
    public class ExportVm
    {
        public ExportVm()
        {
            Orders = new List<OrderVm>();
        }

        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public string CarrierName { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public ICollection<OrderVm> Orders { get; set; }
    }
}
