using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Shipments.Queries.GetShipmentsList
{
    public class GetShipmentsListQuery : IRequest<List<ShipmentViewModel>>
    {
    }
}
