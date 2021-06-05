using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusesList
{
    public class GetShipmentStatusesListQuery : IRequest<List<ShipmentStatusViewModel>>
    {}
}
