using MediatR;
using System;

namespace LogApp.Application.Businesses.Commands.UpdateBusiness
{
    public class UpdateBusinessCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CostCentre { get; set; }
    }
}
