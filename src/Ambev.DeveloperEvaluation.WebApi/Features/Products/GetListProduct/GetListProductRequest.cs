namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Request model for getting a products by Page, size, Order, Direction
/// </summary>
public class GetListProductRequest
{

    /// <summary>
    /// The category ProductsItems list to retrieve
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// The page ProductsItems list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size ProductsItems list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order ProductsItems list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction ProductsItems list to retrieve
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? ColumnFilters { get; set; }

}
