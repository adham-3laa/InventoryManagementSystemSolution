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
	//if the class is used for pagination, you can add properties like PageNumber and PageSize
	private const int MaxPageSize = 50;
	private int _pageSize = 10;
	public int PageSize
	{
		get => _pageSize;
		set => _pageSize = pageSize > MaxPageSize ? MaxPageSize : value;
	}
}

3 paginationResult class like:
public class PaginationResult<T>
{
	public IEnumerable<T> Items { get; set; }
	public int TotalCount { get; set; }
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
}
