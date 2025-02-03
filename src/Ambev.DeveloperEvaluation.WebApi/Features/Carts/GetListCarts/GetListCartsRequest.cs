namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// Request model for getting a Carts by Page, size, Order, Direction, filters and search term
/// </summary>
public class GetListCartsRequest
{
    /// <summary>
    /// The page Carts list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size Carts list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order Carts list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction Carts list to retrieve
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? ColumnFilters { get; set; }

    /// <summary>
    /// The filter Carts list to retrieve
    /// </summary>
    public string? SearchTerm { get; set; }
}
