using MediatR;
using System;

namespace LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus
{
    public class CreateShipmentStatusCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
