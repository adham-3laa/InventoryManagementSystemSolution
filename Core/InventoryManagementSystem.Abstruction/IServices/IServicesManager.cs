using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Abstruction.IServices
{
    public interface IServicesManager
    {
        //add properties for each service interface, for example:
        //IProductService ProductService { get; }
        //we make it get(readonly) because we want to ensure that the services are only set once, typically through dependency injection in the implementation of this interface.
    }
}
