using MediatR;
using System;

namespace LogApp.Application.Carriers.Queries.GetCarrierById
{
    public class GetCarrierByIdQuery : IRequest<CarrierVm>
    {
        public Guid Id { get; set; }
    }
}
