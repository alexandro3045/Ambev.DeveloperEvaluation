
namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;

/// <summary>
/// API response model for CreateCarts operation
/// </summary>
public class CreateCartsResponse : CreateCartsRequest
{
    /// <summary>
    /// The unique identifier of the created carts
    /// </summary>
    public Guid Id { get; set; }
    
}
