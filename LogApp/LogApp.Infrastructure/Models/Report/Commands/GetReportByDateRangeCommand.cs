using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Infrastructure.Models.Report.Commands
{
    public class GetReportByDateRangeCommand : IRequest<List<ShipmentVm>>
    {
        public DateTime StartDate { get; set; }

        public DateTime LastDate { get; set; }
    }
}
