using MediatR;
using System;

namespace LogApp.Application.Businesses.Queries.GetBusinessById
{
    public class GetBusinessByIdQuery : IRequest<BusinessVm>
    {
        public Guid Id { get; set; }
    }
}
