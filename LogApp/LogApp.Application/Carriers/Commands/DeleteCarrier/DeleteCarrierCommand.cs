using MediatR;
using System;

namespace LogApp.Application.Carriers.Commands.DeleteCarrier
{
    public class DeleteCarrierCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
