using LogApp.Application.Orders.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Orders.Queries.GetOrdersByDate
{
    public class GetOrdersByDateQuery : IRequest<List<OrderViewModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
