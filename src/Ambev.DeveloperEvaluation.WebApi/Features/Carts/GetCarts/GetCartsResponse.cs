using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Carts.GetCarts;

/// <summary>
/// API response model for GetCarts operation
/// </summary>
public class GetCartsResponse
{

    /// <summary>
    /// Gets the Id when the carts was created.
    /// </summary>
    public required Guid Id { get; set; }


    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; }


    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public required List<Product> Products { get; set; }
}
