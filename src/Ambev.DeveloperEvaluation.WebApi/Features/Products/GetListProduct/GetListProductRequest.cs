namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Request model for getting a products by Page, size, Order, Direction
/// </summary>
public class GetListProductRequest
{

    /// <summary>
    /// The category Products list to retrieve
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// The page Products list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size Products list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order Products list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction Products list to retrieve
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? ColumnFilters { get; set; }

}
