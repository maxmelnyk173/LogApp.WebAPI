using System;

namespace LogApp.Application.Exports.Queries
{
    public class OrderVm
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public Guid? ExportId { get; set; }
    }
}
