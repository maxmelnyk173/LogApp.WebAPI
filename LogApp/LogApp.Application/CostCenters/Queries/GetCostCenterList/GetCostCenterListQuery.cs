using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.CostCenters.Queries.GetCostCenterList
{
    public class GetCostCenterListQuery : IRequest<List<CostCenterViewModel>>
    {
    }
}
