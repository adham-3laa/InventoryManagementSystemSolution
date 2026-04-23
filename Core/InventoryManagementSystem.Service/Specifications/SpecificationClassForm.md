public class pruductSpecification : BaseSpecification<Product, int>
{
	public pruductSpecification(ProductQueryParams queryParams)
		: base(queryParams.CategoryId.HasValue ? p => p.CategoryId == queryParams.CategoryId : null && queryParams.SearchValue != null ? p => p.Name.Contains(queryParams.SearchValue.ToLower()) : null)
	{
		AddInclude(p=> p.Category);
		switch (queryParams.SortingOption)
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
	public pruductSpecification(ProductQueryParams queryParams)
		: base(queryParams.CategoryId.HasValue ? p => p.CategoryId == queryParams.CategoryId : null)
	{
		AddInclude(p => p.Category);
	}
}
