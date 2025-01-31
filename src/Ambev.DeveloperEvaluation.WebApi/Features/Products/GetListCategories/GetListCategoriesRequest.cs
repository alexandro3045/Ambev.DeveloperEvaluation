namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Request model for getting a products by Page, size, Order, Direction
/// </summary>
public class GetListCategoriesRequest
{
    /// <summary>
    /// The page Products list to retrieve
    /// </summary>
    public int Page { get; set; } = default;

    /// <summary>
    /// The size Products list to retrieve
    /// </summary>
    public int Size { get; set; } = default;

    /// <summary>
    /// The order Products list to retrieve
    /// </summary>
    public string? Order { get; set; } = default;

    /// <summary>
    /// The direction Products list to retrieve
    /// </summary>
    public string? Direction { get; set; } = default;
}
