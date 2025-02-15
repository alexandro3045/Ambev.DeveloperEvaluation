namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

/// <summary>
/// API response model for CreateCarts operation
/// </summary>
public class CartsResponse : CartsRequest
{
    /// <summary>
    /// The unique identifier of the created carts
    /// </summary>
    public Guid Id { get; set; }
}
