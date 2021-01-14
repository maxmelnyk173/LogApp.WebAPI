using System;

namespace LogApp.Domain.Common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? Deleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
