using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Domain.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
