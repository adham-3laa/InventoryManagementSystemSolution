using AutoMapper;
using InventoryManagementSystem.Abstruction.IServices;
using InventoryManagementSystem.Domain.Contracts.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Service.Services
{
    public class ServicesManager(IMapper mapper,IUnitOfWork unitOfWork) : IServicesManager
    {
        // Constructor to initialize the lazy services
        // The services will be initialized when they are accessed for the first time, ensuring that we only create instances of the services when they are actually needed.
        // This approach can help improve performance and reduce memory usage, especially if some services are not always required during the application's lifecycle.
        // Example of a lazy service property
        // private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(mapper, unitOfWork));
        // public IProductService ProductService => _productService.Value;
        // You can add similar lazy properties for other services as needed.
        // Note: The actual implementation of the services (like ProductService) would need to be created separately, and they would typically take the IMapper and IUnitOfWork as dependencies in their constructors.
        
    }
}
