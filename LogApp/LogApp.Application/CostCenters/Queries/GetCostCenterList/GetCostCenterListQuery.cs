using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Businesses.Queries.GetCostCenterList
{
    public class GetCostCenterListQuery : IRequest<List<CostCenterViewModel>>
    {
    }
}
