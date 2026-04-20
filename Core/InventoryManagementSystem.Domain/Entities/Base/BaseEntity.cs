using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Domain.Entities.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; } = default!;
    }
}
