using LogApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Infrastructure.Models.Report
{
    public class ShipmentOrderVm
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public PackingType PackingType { get; set; }

        public int GoodsQuantity { get; set; }

        public string Dimensions { get; set; }

        public int Weight { get; set; }

        public Stackability Stackability { get; set; }

        public string Business { get; set; }

        public int CostCentre { get; set; }

        public int GoodsGL { get; set; }

        public string GoodsType { get; set; }
    }
}
