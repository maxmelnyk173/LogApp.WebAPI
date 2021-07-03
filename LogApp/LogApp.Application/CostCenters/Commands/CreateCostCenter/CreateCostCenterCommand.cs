using MediatR;
using System;

namespace LogApp.Application.CostCenters.Commands.CreateCostCenter
{
    public class CreateCostCenterCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string CostCenterCode { get; set; }
    }
}
