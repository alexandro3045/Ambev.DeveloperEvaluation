using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;

/// <summary>
/// Represents a request to Update a new Carts in the system.
/// </summary>
public class UpdateCartsRequest : CartsRequest 
{
    /// <summary>
    /// Gets the Id when the carts was created.
    /// </summary>
    public required Guid Id { get; set; }
}