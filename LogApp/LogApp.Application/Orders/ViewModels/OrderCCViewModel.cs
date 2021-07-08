using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Orders.ViewModels
{
    public class OrderCCViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CostCentre { get; set; }
    }
}
