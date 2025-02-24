using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;

/// <summary>
/// Represents a request to update a new SalesCarts in the system.
/// </summary>
public class SalesCartsRequestUpdate : BaseSalesCartsRequest
{
    /// <summary>
    /// Gets the canceled and time when the carts was updated.
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// Gets the CartsRequestUpdate when the carts was updated.
    /// </summary>
    public required CartsRequestUpdate Carts { get; init; }
}
