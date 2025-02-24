using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;

/// <summary>
/// Represents a request to create a new salesCarts in the system.
/// </summary>
public class SalesCartsRequest : BaseSalesCartsRequest
{
    public required CartsRequest Carts { get; set; }
}
