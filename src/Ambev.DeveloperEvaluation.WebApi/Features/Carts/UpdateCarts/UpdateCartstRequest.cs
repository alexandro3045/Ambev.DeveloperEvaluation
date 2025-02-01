using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCards;

/// <summary>
/// Represents a request to Update a new Carts in the system.
/// </summary>
public class UpdateCartsRequest
{

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets the UserID from Carts
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the date from Carts
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Gets the description from Carts.
    /// </summary>
    public required List<Product> Products { get; set; }
}