using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Shared.ErrorModels
{
    public class ErrorToReturn
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }=null!;
    }
}
