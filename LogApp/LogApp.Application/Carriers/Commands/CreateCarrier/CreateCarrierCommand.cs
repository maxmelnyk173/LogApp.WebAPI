using MediatR;
using System;

namespace LogApp.Application.Carriers.Commands.CreateCarrier
{
    public class CreateCarrierCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
