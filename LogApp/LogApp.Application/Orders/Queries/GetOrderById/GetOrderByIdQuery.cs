using LogApp.Application.Orders.Queries.ViewModels;
using MediatR;
using System;

namespace LogApp.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderViewModel>
    {
        public Guid Id { get; set; }
    }
}
