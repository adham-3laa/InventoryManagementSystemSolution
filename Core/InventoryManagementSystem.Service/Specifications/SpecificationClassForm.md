public class pruductSpecification : BaseSpecification<Product, int>
{
	public pruductSpecification(int? CategoryId, ProductSortingOptions? SortingOption)
		: base(CategoryId)
	{
		AddInclude(p=> p.Category);
		switch (SortingOption)
		{
			case ProductSortingOptions.NameAsc:
				AddOrderBy(p => p.Name);
				break;
			case ProductSortingOptions.NameDesc:
				AddOrderByDescending(p => p.Name);
				break;
			case ProductSortingOptions.PriceAsc:
				AddOrderBy(p => p.Price);
				break;
			case ProductSortingOptions.PriceDesc:
				AddOrderByDescending(p => p.Price);
				break;
		}
	}
	public pruductSpecification(int id)
		: base(p => p.Id == id)
	{
		AddInclude(p => p.Category);
	}
}
