using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Exports.Commands.CreateExport
{
    public class CreateExportCommand : IRequest<Guid>
    {
        public CreateExportCommand()
        {
            Orders = new List<GetExportOrderVm>();
        }

        public Guid Id { get; set; }

        public Guid CarrierId { get; set; }

        public string TruckNumber { get; set; }

        public string DriverDetails { get; set; }

        public string TruckType { get; set; }

        public string Route { get; set; }

        public decimal Price { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string LogisticsNotes { get; set; }

        public ICollection<GetExportOrderVm> Orders { get; set; }
    }
}
