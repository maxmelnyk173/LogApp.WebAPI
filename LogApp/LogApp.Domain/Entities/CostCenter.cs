using LogApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class CostCenter : AuditEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CostCentre { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
