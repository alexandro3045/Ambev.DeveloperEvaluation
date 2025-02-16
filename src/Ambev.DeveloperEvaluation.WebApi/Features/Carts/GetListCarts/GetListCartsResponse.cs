
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetListCarts;

/// <summary>
/// API response model for ListCartsOperation
/// </summary>
public class GetListCartsResponse
{
    /// <summary>
    /// The list Carts
    /// </summary>
    public List<CartsResponse>? ListCarts { get; set; }
}
