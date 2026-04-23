it contains the following classes:
1 Enums for Queries like:
ProductSortingOptions enum
{
	NameAsc 1,
	NameDesc 2,
	PriceAsc 3,
	PriceDesc 4
}
2 QuaryParams class like:
public class ProductQueryParams
{
	public int? CategoryId { get; set; }
	public ProductSortingOptions? SortingOption { get; set; }
	public string? SearchValue { get; set; }
}
