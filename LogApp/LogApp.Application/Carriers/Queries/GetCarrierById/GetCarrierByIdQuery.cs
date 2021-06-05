using MediatR;
using System;

namespace LogApp.Application.Carriers.Queries.GetCarrierById
{
    public class GetCarrierByIdQuery : IRequest<CarrierViewModel>
    {
        public Guid Id { get; set; }
    }
}
