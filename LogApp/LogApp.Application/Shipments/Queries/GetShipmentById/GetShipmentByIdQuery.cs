using LogApp.Application.Shipments.Queries.ViewModels;
using MediatR;
using System;

namespace LogApp.Application.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByIdQuery : IRequest<ShipmentViewModel>
    {
        public Guid Id { get; set; }
    }
}
