using MediatR;
using System;

namespace LogApp.Application.Carriers.Commands.UpdateCarrier
{
    public class UpdateCarrierCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateCarrierViewModel Carrier { get; set; }
    }
}
