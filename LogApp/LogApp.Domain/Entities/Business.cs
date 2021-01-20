using LogApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class Business : AuditEntity
    {
        public Business()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CostCentre { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
