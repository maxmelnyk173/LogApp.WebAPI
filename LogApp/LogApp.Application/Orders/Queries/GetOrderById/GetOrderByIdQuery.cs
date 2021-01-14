using MediatR;
using System;

namespace LogApp.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderVm>
    {
        public Guid Id { get; set; }
    }
}
