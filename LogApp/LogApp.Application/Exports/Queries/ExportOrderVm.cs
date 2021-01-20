using System;

namespace LogApp.Application.Exports.Queries
{
    public class ExportOrderVm
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public Guid? ExportId { get; set; }
    }
}
