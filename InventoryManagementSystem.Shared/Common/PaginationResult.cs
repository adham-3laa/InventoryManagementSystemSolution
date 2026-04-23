using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Shared.Common
{
    public class PaginationResult<TEntity>
    {
        public IEnumerable<TEntity> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
