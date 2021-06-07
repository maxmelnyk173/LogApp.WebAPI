using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Orders.Queries.ViewModels
{
    public class OrderShipmentViewModel
    {
        public Guid Id { get; set; }

        public string TruckNumber { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
