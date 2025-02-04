
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCarts;

/// <summary>
/// API response model for UpdateProduct operation
/// </summary>
public class UpdateCartsResponse
{
    /// <summary>
    /// Gets the date and time when the carts was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the UserId when the carts was created.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the products when the carts was created.
    /// </summary>
    public required List<Product> Products { get; set; }
}
