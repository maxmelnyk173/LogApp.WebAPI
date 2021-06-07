using LogApp.Domain.Entities;
using LogApp.Domain.Enums;
using MediatR;
using System;

namespace LogApp.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }

        public UpdateOrderViewModel Order { get; set; }
    }
}
