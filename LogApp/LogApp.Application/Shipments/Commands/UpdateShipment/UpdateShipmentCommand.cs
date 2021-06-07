using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Shipments.Commands.UpdateShipment
{
    public class UpdateShipmentCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateShipmentViewModel Shipment { get; set; }
    }
}
