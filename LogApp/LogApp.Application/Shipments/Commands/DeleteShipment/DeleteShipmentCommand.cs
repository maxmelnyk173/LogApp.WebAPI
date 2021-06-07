using MediatR;
using System;

namespace LogApp.Application.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
