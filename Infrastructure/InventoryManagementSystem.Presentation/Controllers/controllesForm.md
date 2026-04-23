[ApiController]
[Route("api/[controller]")]
public class ProductsController(IServicesManager servicesManager) : ControllerBase
{
	[HttpGet]
	public async task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery]	ProductQueryParams queryParams)
	{
		var products = await servicesManager.ProductService.GetAllProductsAsync(queryParams.CategoryId, queryParams.SortingOption);
		return Ok(products);
	}
	[HttpGet("{id}")]
	public async task<ActionResult<ProductDto>> GetProductById(int id)
	{
		var product = await servicesManager.ProductService.GetProductByIdAsync(id);
		if (product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}
}
	