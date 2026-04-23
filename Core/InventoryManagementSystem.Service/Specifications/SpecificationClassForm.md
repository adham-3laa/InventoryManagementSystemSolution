public class pruductSpecification : BaseSpecification<Product, int>
{
	public pruductSpecification()
		: base(null)
	{
		AddInclude(p=> p.Category);
	}
	public pruductSpecification(int id)
		: base(p => p.Id == id)
	{
		AddInclude(p => p.Category);
	}
}
