using LogApp.Application.Orders.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrderViewModel>>
    {
    }
}
