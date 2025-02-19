using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.CreateCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// Represents a request to Update a new Carts in the system.
/// </summary>
public class UpdateSalesCartsRequest : CreateSalesCartsRequest
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets the date and time when the carts was updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets the canceled and time when the carts was updated.
    /// </summary>
    public bool Canceled { get; set; }
}