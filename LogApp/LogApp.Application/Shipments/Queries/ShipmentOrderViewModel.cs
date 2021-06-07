using System;

namespace LogApp.Application.Shipments.Queries
{
    public class ShipmentOrderViewModel
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public Guid? ImportId { get; set; }
    }
}
