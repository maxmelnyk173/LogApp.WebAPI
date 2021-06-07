using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public Carrier Carrier { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }
    }
}
