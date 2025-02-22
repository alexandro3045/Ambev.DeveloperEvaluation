using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;

/// <summary>
/// Represents a request to update a new SalesCarts in the system.
/// </summary>
public class SalesCartsRequestUpdate : BaseSalesCartsRequest
{
    /// <summary>
    /// Gets the Id when the carts was created/updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the CartsRequestUpdate when the carts was updated.
    /// </summary>
    public required CartsRequestUpdate Carts { get; init; }

}
