﻿using LogApp.Domain.Enums;
using System;

namespace LogApp.Application.Shipments.Queries.ViewModels
{
    public class ShipmentOrderViewModel
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

        public ShipmentCCViewModel CostCenter { get; set; }

        public string GoodsType { get; set; }
    }
}
