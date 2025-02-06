using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Represents a request to Update a new SalesCarts in the system.
/// </summary>
public class UpdateSalesCartsRequest
{

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets the UserID from SalesCarts
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the date from SalesCarts
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Gets the products from SalesCarts.
    /// </summary>
    public required List<Item> Products { get; set; }
}