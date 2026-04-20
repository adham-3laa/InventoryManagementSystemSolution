using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Domain.Entities.Base
{
    public abstract class AuditableEntity<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
