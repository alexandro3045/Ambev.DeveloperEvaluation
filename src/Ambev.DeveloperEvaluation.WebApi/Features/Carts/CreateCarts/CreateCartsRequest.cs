using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCarts;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CreateCartsRequest
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
    public required List<Item> Products { get; set; }
}
