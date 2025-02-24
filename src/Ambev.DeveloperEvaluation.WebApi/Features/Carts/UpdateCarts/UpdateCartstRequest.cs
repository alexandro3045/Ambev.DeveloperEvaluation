using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;

/// <summary>
/// Represents a request to Update a new Carts in the system.
/// </summary>
public class UpdateCartsRequest : CartsRequest
{
    public UpdateCartsRequest(string userId, List<ItemProduct> products) { }
}