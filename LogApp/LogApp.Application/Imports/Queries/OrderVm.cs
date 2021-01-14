using System;

namespace LogApp.Application.Imports.Queries
{
    public class OrderVm
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public Guid? ImportId { get; set; }
    }
}
