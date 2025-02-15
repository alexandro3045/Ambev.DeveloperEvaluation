using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Represents a request to Update a new Carts in the system.
/// </summary>
public class UpdateSalesCartsRequest
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
    /// Gets the products from Carts.
    /// </summary>
    public required List<Product> Products { get; set; }
}