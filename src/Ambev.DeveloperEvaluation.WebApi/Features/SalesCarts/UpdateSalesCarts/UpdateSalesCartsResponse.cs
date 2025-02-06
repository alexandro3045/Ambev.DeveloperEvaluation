
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.UpdateSalesCarts;

/// <summary>
/// API response model for UpdateSalesCarts operation
/// </summary>
public class UpdateSalesCartsResponse
{
    /// <summary>
    /// Gets the date and time when the salescarts was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the UserId when the salescarts was created.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets the products when the salescarts was created.
    /// </summary>
    public required List<Product> Products { get; set; }
}
