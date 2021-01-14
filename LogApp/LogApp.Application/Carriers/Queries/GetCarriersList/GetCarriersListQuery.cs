using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Carriers.Queries.GetCarriersList
{
    public class GetCarriersListQuery : IRequest<List<CarrierVm>>
    {
    }
}
