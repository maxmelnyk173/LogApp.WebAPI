using MediatR;
using System;

namespace LogApp.Application.CostCenters.Commands.UpdateCostCenter
{
    public class UpdateCostCenterCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateCostCenterViewModel CostCenter { get; set; }
    }
}
