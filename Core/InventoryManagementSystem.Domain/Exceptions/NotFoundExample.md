
public classProductNotFoundException : NotFoundException
{
	public sealed ProductNotFoundException(int productId)
		: base($"Product with ID {productId} was not found.")
	{
	}
}