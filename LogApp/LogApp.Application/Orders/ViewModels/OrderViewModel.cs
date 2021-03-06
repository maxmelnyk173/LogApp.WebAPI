﻿ using LogApp.Domain.Entities;
using LogApp.Domain.Enums;
using System;

namespace LogApp.Application.Orders.ViewModels
{
    public class OrderViewModel
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

        public OrderCCViewModel CostCenter { get; set; }

        public int GoodsGL { get; set; }

        public string GoodsType { get; set; }

        public string Notes { get; set; }

        public bool IsAccepted { get; set; }

        public OrderShipmentViewModel Shipment { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime Created { get; set; }
    }
}
