using LogApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommand : IRequest<Guid>
    {
        public ShipmentCommandViewModel Shipment { get; set; }
    }
}
