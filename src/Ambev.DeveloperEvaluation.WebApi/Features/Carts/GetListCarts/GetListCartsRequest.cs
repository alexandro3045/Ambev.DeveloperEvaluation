namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// Request model for getting a Carts by Page, size, Order, Direction
/// </summary>
public class GetListCartsRequest
{
    /// <summary>
    /// The page Cartss list to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The size Cartss list to retrieve
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The order Cartss list to retrieve
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// The direction Cartss list to retrieve
    /// </summary>
    public string? Direction { get; set; }
}
