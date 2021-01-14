using MediatR;
using System;

namespace LogApp.Application.Businesses.Commands.CreateBusiness
{
    public class CreateBusinessCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public int CostCentre { get; set; }
    }
}
