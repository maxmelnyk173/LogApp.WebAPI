﻿using LogApp.Application.Orders.ViewModels;
using LogApp.Domain.Entities;
using LogApp.Domain.Enums;
using MediatR;
using System;

namespace LogApp.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderViewModel>
    {
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

        public Guid CostCenterId { get; set; }

        public int GoodsGL { get; set; }

        public string GoodsType { get; set; }

        public string Notes { get; set; }
    }
}
