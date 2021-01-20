using MediatR;
using System;

namespace LogApp.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
