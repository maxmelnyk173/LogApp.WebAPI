using MediatR;
using System;

namespace LogApp.Application.CostCenters.Commands.DeleteCostCenter
{
    public class DeleteCostCenterCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
