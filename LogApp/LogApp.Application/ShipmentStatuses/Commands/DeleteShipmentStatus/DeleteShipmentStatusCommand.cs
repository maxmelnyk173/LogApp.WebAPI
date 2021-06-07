using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Commands.DeleteShipmentStatus
{
    public class DeleteShipmentStatusCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
