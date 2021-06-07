using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Commands.UpdateShipmentStatus
{
    public class UpdateShipmentStatusCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateShipmentStatusViewModel Status { get; set; }
    }
}

