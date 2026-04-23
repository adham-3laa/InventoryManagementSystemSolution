using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Shared.ErrorModels
{
    public class ValidationError
    {
        public string Field { get; set; } = null!;
        public IEnumerable<string> Errors { get; set; } = null!;
    }
}
