using LogApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace LogApp.Domain.Entities
{
    public class Carrier : AuditEntity
    {
        public Carrier()
        {
            Exports = new HashSet<Export>();

            Imports = new HashSet<Import>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Export> Exports { get; set; }
        public ICollection<Import> Imports { get; set; }

    }
}
