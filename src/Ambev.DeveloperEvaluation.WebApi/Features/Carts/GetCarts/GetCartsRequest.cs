
namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;

/// <summary>
/// Request model for getting a Carts by ID
/// </summary>
public class GetCartsRequest
{
    /// <summary>
    /// The unique identifier of the carts to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
