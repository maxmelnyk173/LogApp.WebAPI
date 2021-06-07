using LogApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class Carrier : AuditEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Shipment> Shipments {get; set;}
    }
}
