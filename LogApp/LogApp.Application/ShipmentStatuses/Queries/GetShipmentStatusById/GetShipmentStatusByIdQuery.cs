using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusById
{
    public class GetShipmentStatusByIdQuery : IRequest<ShipmentStatusViewModel>
    {
        public Guid Id { get; set; }
    }
}
