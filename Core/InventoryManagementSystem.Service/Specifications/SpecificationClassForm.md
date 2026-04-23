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


an other specification ClassForm for pagginationCount
public class CountProductSpecifications : BaseSpecification<Product, int>
{
	public CountProductSpecifications(ProductQueryParams queryParams)
		: base(queryParams.CategoryId.HasValue ? p => p.CategoryId == queryParams.CategoryId : null && queryParams.SearchValue != null ? p => p.Name.Contains(queryParams.SearchValue.ToLower()) : null)
	{
		// No need to include related entities for counting
		//it will be used to count the total number of products that match the filtering criteria, so we only need to apply the same filtering conditions as in the pruductSpecification class without including related entities.
	}
}