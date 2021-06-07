using MediatR;
using System;

namespace LogApp.Application.CostCenters.Queries.GetCostCenterById
{
    public class GetCostCenterByIdQuery : IRequest<CostCenterViewModel>
    {
        public Guid Id { get; set; }
    }
}
